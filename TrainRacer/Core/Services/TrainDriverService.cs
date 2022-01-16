using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using TrainRacer.Contract;
using TrainRacer.Contract.Events;
using TrainRacer.Contract.Extensions;

namespace TrainRacer.Core.Services;

public class TrainDriverService : ITrainDriverService
{
    private readonly Timer _trainTimer;

    public TrainDriverService(ITrain train, double intervalMilliseconds, IEnumerable<IDriver> availableDrivers)
    {
        if (train == null)
        {
            throw new ArgumentException("No train provided.");
        }

        if (availableDrivers?.Any() != true)
        {
            throw new ArgumentException("No drivers provided.");
        }

        _trainTimer = new Timer(intervalMilliseconds);

        var driver = availableDrivers.GetRandom();

        _trainTimer.Elapsed += (s, e) =>
        {
            driver?.DriveTrain(train, intervalMilliseconds);
            DistanceUpdated?.Invoke(this, new DistanceUpdatedEventArgs(train));
        };
    }

    public event EventHandler<DistanceUpdatedEventArgs>? DistanceUpdated;

    public void Dispose()
    {
        _trainTimer.Dispose();
    }

    public void StartTrain()
    {
        _trainTimer.Start();
    }

    public void StopTrain()
    {
        _trainTimer.Stop();
    }
}


