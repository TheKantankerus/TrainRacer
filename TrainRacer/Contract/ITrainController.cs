using System;
using System.Collections.Generic;
using TrainRacer.Events;

namespace TrainRacer.Contract
{
    public interface ITrainController
    {
        IEnumerable<ITrain> RunningTrains
        {
            get;
        }

        void StartTrain(ITrain train, double interval);
        void StopTrain(ITrain train);

        public event EventHandler<DistanceUpdatedEventArgs> DistanceUpdated;
    }
}
