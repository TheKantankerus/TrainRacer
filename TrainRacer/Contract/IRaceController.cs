using System;
using System.Collections.Generic;
using TrainRacer.Contract.Events;

namespace TrainRacer.Contract
{
    public interface IRaceController
    {
        TimeSpan TimeElapsed
        {
            get;
        }

        event Action RaceComplete;
        event EventHandler<RaceUpdatedEventArgs> RaceUpdated;

        void StartRace(IEnumerable<ITrain> trains, ITrack track);
    }
}
