using System;
using System.Timers;
using TrainRacer.Contract;
using TrainRacer.Contract.Events;
using TrainRacer.Contract.Extensions;

namespace TrainRacer.Core.Services;

public class TrainDriverService : ITrainDriverService
{
    private readonly ITrain _train;
    private readonly Timer _trainTimer;

    public TrainDriverService(ITrain train, double intervalMilliseconds)
    {
        _train = train;
        _trainTimer = new Timer(intervalMilliseconds);
        _trainTimer.Elapsed += (s, e) => UpdateDistance();
    }

    public event EventHandler<DistanceUpdatedEventArgs>? DistanceUpdated;

    public void Dispose()
    {
        StopTrain();
        _trainTimer.Elapsed -= (s, e) => UpdateDistance();
    }

    public void StartTrain()
    {
        _trainTimer.Start();
    }

    public void StopTrain()
    {
        _trainTimer.Stop();
    }

    private void UpdateDistance()
    {
        _train.Accelerate(_trainTimer.Interval).Travel(_trainTimer.Interval);
        DistanceUpdated?.Invoke(this, new DistanceUpdatedEventArgs { Train = _train });
    }
}


