using Microsoft.Xaml.Behaviors.Core;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using TrainRacer.Contract;

namespace TrainRacer
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRaceController _raceController;
        private readonly ITrainController _trainController;

        public MainWindowViewModel(IRaceController raceController,
                             ITrainController trainController)
        {
            _raceController = raceController;
            _raceController.RaceComplete += OnRaceCompleted;
            _trainController = trainController;
            _trainController.DistanceUpdated += OnDistanceUpdated;

            StartRaceCommand = new ActionCommand(StartRace);
        }

        public ActionCommand StartRaceCommand
        {
            get;
        }

        public ObservableCollection<ITrain> AvailableTrains
        {
            get;
        } = new();

        public ObservableCollection<ITrain> SelectedTrains
        {
            get;
        } = new();

        public ObservableCollection<ITrack> AvailableTracks
        {
            get;
        } = new();

        public ObservableCollection<RaceResult> RaceResults
        {
            get;
        } = new();

        public ITrack? SelectedTrack
        {
            get; set;
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            private set => SetProperty(ref _errorMessage, value);
        }
        private string _errorMessage;

        private bool _canRace;

        public bool CanRace
        {
            get => _canRace;
            private set => SetProperty(ref _canRace, value);
        }

        private void StartRace()
        {
            if (!SelectedTrains.Any())
            {
                ErrorMessage = "Please select one or more trains to race.";
                return;
            }
            if (SelectedTrack == null)
            {
                ErrorMessage = "Please select a track.";
                return;
            }
            _raceController.StartRace(SelectedTrains, SelectedTrack);
            CanRace = false;
        }

        private void OnRaceCompleted(object? sender, Events.RaceCompleteEventArgs e)
        {
            CanRace = true;
            RaceResults.Clear();
            RaceResults.AddRange(e.Results);
        }

        private void OnDistanceUpdated(object? sender, Events.DistanceUpdatedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
