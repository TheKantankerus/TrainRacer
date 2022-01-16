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
    private ITrack? _track;
    private int _trainCount;

    public TimeSpan TimeElapsed => TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds);

    public event Action RaceComplete;
    public event EventHandler<RaceUpdatedEventArgs> RaceUpdated;

    public void StartRace(IEnumerable<ITrain> trains, ITrack track)
    {
        _track = track;
        _trainCount = trains.Count();
        _results.Clear();
        _stopwatch.Restart();
        foreach (var train in trains)
        {
            var driverService = new TrainDriverService(train, 100);

            driverService.DistanceUpdated += OnDistanceUpdated;

            driverService.StartTrain();
        }
    }

    private void OnDistanceUpdated(object? sender, DistanceUpdatedEventArgs e)
    {
        if (IsTrainFinished(e.Train) &&
            sender is ITrainDriverService driverService)
        {
            driverService.Dispose();
            var result = new RaceResult()
            {
                Train = e.Train,
                FinishTime = _stopwatch.Elapsed
            };
            _results.Add(result);
            RaceUpdated?.Invoke(this, new RaceUpdatedEventArgs() { RaceResult = result });

            if (IsRaceComplete())
            {
                FinishRace();
            }
        }
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


