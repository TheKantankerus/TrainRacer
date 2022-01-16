using System;
using TrainRacer.Contract.Events;

namespace TrainRacer.Contract
{
    public interface ITrainDriverService : IDisposable
    {
        void StartTrain();
        void StopTrain();

        public event EventHandler<DistanceUpdatedEventArgs> DistanceUpdated;
    }
}
