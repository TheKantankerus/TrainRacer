using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TrainRacer.Contract;
using TrainRacer.Contract.Events;
using TrainRacer.Core.Services;

namespace TrainRacer.Core.Controllers;

public class RaceController : IRaceController
{
    private readonly Stopwatch _stopwatch = new();
    private readonly List<RaceResult> _results = new();
    private readonly IEnumerable<IDriver> _availableDrivers;
    private ITrack? _track;
    private int _trainCount;
    private DateTime _lastFinishTime;

    public RaceController(IEnumerable<IDriver> availableDrivers)
    {
        _availableDrivers = availableDrivers;
    }

    public TimeSpan TimeElapsed => TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds);

    public event Action? RaceComplete;
    public event EventHandler<RaceUpdatedEventArgs>? RaceUpdated;

    public void StartRace(IEnumerable<ITrain> trains, ITrack track)
    {
        _track = track;
        _trainCount = trains.Count();
        _results.Clear();
        _stopwatch.Restart();
        foreach (ITrain? train in trains)
        {
            TrainDriverService? driverService = new(train, 100, _availableDrivers);

            driverService.DistanceUpdated += OnDistanceUpdated;

            driverService.StartTrain();
        }
    }

    private void OnDistanceUpdated(object? sender, DistanceUpdatedEventArgs e)
    {
        if (e.Train == null
            || sender is not ITrainDriverService driverService)
        {
            return;
        }

        if (IsTrainFinished(e.Train))
        {
            _lastFinishTime = DateTime.Now;

            driverService.Dispose();
            ReportFinishedTrain(e.Train);
        }
        else
        {
            if (_results.Count == 0 ||
                DateTime.Now - _lastFinishTime <= TimeSpan.FromSeconds(10))
            {
                return;
            }
            driverService.StopTrain();
            driverService.Dispose();

            ReportLateTrain(e.Train);
        }

        if (IsRaceComplete())
        {
            FinishRace();
        }
    }

    private void ReportFinishedTrain(ITrain train)
    {
        RaceResult result = new()
        {
            Train = train,
            FinishTime = _stopwatch.Elapsed
        };
        _results.Add(result);
        RaceUpdated?.Invoke(this, new RaceUpdatedEventArgs() { RaceResult = result });
    }

    private void ReportLateTrain(ITrain train)
    {
        RaceResult result = new()
        {
            Train = train
        };
        _results.Add(result);
        RaceUpdated?.Invoke(this, new RaceUpdatedEventArgs() { RaceResult = result });
    }

    private bool IsTrainFinished(ITrain train)
    {
        if (train == null ||
            _track == null)
        {
            return false;
        }

        return train.DistanceTraveled >= _track.Length;
    }

    private bool IsRaceComplete()
    {
        return _results.Count == _trainCount;
    }

    private void FinishRace()
    {
        _stopwatch.Stop();
        RaceComplete?.Invoke();
    }
}


