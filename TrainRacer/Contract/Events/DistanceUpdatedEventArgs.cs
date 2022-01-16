using System;

namespace TrainRacer.Contract.Events
{
    public class DistanceUpdatedEventArgs : EventArgs
    {
        public DistanceUpdatedEventArgs(ITrain train)
        {
            Train = train;
        }

        public ITrain? Train
        {
            get;
        }
    }
}
