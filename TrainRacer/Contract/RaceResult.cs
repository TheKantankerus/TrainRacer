using System;

namespace TrainRacer.Contract
{
    public record struct RaceResult
    {
        public ITrain Train
        {
            get; init;
        }

        public TimeSpan? FinishTime
        {
            get; init;
        }
    }
}
