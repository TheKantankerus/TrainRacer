using System;

namespace TrainRacer.Contract.Events
{
    public class RaceUpdatedEventArgs : EventArgs
    {
        public RaceResult RaceResult
        {
            get; init;
        }
    }
}
