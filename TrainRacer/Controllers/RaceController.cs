using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TrainRacer.Contract;
using TrainRacer.Events;

namespace TrainRacer.Core
{
    public class RaceController : IRaceController
    {
        private readonly ITrainController _trainController;
        private readonly Stopwatch _stopwatch = new();
        private readonly List<RaceResult> _results = new();
        private ITrack _track;

        public RaceController(ITrainController trainController)
        {
            _trainController = trainController;
            _trainController.DistanceUpdated += OnDistanceUpdated;
        }

        public TimeSpan TimeElapsed => TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds);

        public event EventHandler<RaceCompleteEventArgs> RaceComplete;

        public void StartRace(IEnumerable<ITrain> trains, ITrack track)
        {
            _track = track;
            _results.Clear();
            _stopwatch.Restart();
            foreach (var train in trains)
            {
                _trainController.StartTrain(train, 100);
            }
        }

        private void OnDistanceUpdated(object? sender, DistanceUpdatedEventArgs e)
        {
            if (IsTrainFinished(e.Train))
            {
                _trainController.StopTrain(e.Train);

                _results.Add(new RaceResult() { Train = e.Train, FinishTime = _stopwatch.Elapsed });

                if (IsRaceComplete())
                {
                    FinishRace();
                }
            }
        }

        private bool IsTrainFinished(ITrain train)
        {
            if (train == null ||
                _track == null)
            {
                return false;
            }

            return train.DistanceTraveled >= _track.Length;
        }

        private bool IsRaceComplete()
        {
            return !_trainController.RunningTrains.Any();
        }

        private void FinishRace()
        {
            _stopwatch.Stop();
            RaceComplete?.Invoke(this, new RaceCompleteEventArgs(_results));
        }
    }
}


