using System;
using System.Collections.Generic;
using TrainRacer.Events;

namespace TrainRacer.Contract
{
    public interface IRaceController
    {
        TimeSpan TimeElapsed
        {
            get;
        }

        event EventHandler<RaceCompleteEventArgs> RaceComplete;

        void StartRace(IEnumerable<ITrain> trains, ITrack track);
    }
}
