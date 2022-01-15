using System;
using TrainRacer.Contract;

namespace TrainRacer.Events
{
    public class DistanceUpdatedEventArgs : EventArgs
    {
        public ITrain Train
        {
            get; init;
        }
    }
}
