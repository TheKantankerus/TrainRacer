using System;

namespace TrainRacer.Contract.Events
{
    public class DistanceUpdatedEventArgs : EventArgs
    {
        public ITrain? Train
        {
            get; init;
        }
    }
}
