using System;

namespace TrainRacer.Contract
{
    public struct RaceResult
    {
        public ITrain Train
        {
            get; init;
        }

        public TimeSpan FinishTime
        {
            get; init;
        }
    }
}
