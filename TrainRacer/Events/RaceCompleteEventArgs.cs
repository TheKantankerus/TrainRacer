using System;
using System.Collections.Generic;
using TrainRacer.Contract;

namespace TrainRacer.Events
{
    public class RaceCompleteEventArgs : EventArgs
    {
        public RaceCompleteEventArgs(List<RaceResult> results)
        {
            Results.AddRange(results);
        }

        public List<RaceResult> Results
        {
            get;
        } = new();
    }
}
