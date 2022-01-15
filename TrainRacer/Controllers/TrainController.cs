using System;
using System.Collections.Generic;
using System.Timers;
using TrainRacer.Contract;
using TrainRacer.Events;
using TrainRacer.Extensions;

namespace TrainRacer.Core
{
    public class TrainController : ITrainController
    {
        private readonly Dictionary<ITrain, Timer> _runningTrains = new();

        public IEnumerable<ITrain> RunningTrains => _runningTrains.Keys;

        public event EventHandler<DistanceUpdatedEventArgs> DistanceUpdated;

        public void StartTrain(ITrain train, double interval)
        {
            var trainTimer = new Timer(interval);
            trainTimer.Elapsed += (s, e) => UpdateDistance(train, interval);
            if (!_runningTrains.ContainsKey(train))
            {
                _runningTrains.Add(train, trainTimer);
            }
        }

        public void StopTrain(ITrain train)
        {
            if (_runningTrains.ContainsKey(train))
            {
                _runningTrains[train].Stop();
                _runningTrains.Remove(train);
            }
        }

        private void UpdateDistance(ITrain train, double interval)
        {
            train.Accelerate(interval).Travel(interval);
            DistanceUpdated?.Invoke(this, new DistanceUpdatedEventArgs { Train = train });
        }
    }
}


