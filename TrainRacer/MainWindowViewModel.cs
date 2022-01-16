using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using TrainRacer.Contract;

namespace TrainRacer
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRaceController _raceController;
        private readonly bool _isRaceReset = true;

        public MainWindowViewModel(IRaceController raceController,
                             IEnumerable<ITrain> availableTrains,
                             IEnumerable<ITrack> availableTracks)
        {
            _raceController = raceController;
            _raceController.RaceComplete += OnRaceCompleted;
            _raceController.RaceUpdated += OnRaceUpdated;

            StartRaceCommand = new DelegateCommand(StartRace, () => !_isRaceRunning && _isRaceReset);
            ResetRaceCommand = new DelegateCommand(ResetRace, () => RaceResults.Any());
            TrainSelectedCommand = new DelegateCommand<ITrain>(TrainSelected);
            TrainDeselectedCommand = new DelegateCommand<ITrain>(TrainDeselected);

            AvailableTrains = availableTrains;
            AvailableTracks.AddRange(availableTracks);

            SelectedTrains.CollectionChanged += OnSelectedTrainsChanged;

            //TODO: Remove, these are just for debugging
            SelectedTrack = availableTracks.FirstOrDefault();
        }

        public DelegateCommand StartRaceCommand
        {
            get;
        }

        public DelegateCommand ResetRaceCommand
        {
            get;
        }

        public DelegateCommand<ITrain> TrainSelectedCommand
        {
            get;
        }

        public DelegateCommand<ITrain> TrainDeselectedCommand
        {
            get;
        }

        public IEnumerable<ITrain> AvailableTrains
        {
            get;
        }

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
            private set
            {
                SetProperty(ref _errorMessage, value);
                RaisePropertyChanged(nameof(IsErrorMessageVisible));
            }
        }
        private string _errorMessage = string.Empty;

        public bool IsErrorMessageVisible => !string.IsNullOrEmpty(ErrorMessage);

        public bool IsRaceCompleted
        {
            get => _isRaceCompleted;
            private set
            {
                SetProperty(ref _isRaceCompleted, value);
                IsRaceRunning = !_isRaceCompleted;
            }
        }
        private bool _isRaceCompleted;

        public bool IsRaceRunning
        {
            get => _isRaceRunning;
            private set => SetProperty(ref _isRaceRunning, value);
        }
        private bool _isRaceRunning = false;

        #region Execute Command Methods

        private void ResetRace()
        {
            SelectedTrains.Clear();
            RaceResults.Clear();
            foreach (ITrain? train in AvailableTrains)
            {
                train.DistanceTraveled = 0;
            }
            StartRaceCommand.RaiseCanExecuteChanged();
            ResetRaceCommand.RaiseCanExecuteChanged();
        }

        private void TrainDeselected(ITrain train)
        {
            SelectedTrains.Remove(train);
        }

        private void TrainSelected(ITrain train)
        {
            SelectedTrains.Add(train);
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
            IsRaceCompleted = false;

            StartRaceCommand.RaiseCanExecuteChanged();
        }

        #endregion

        private void OnRaceCompleted()
        {
            IsRaceCompleted = true;

            ResetRaceCommand.RaiseCanExecuteChanged();
        }

        private void OnRaceUpdated(object? sender, Contract.Events.RaceUpdatedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => RaceResults.Add(e.RaceResult));
        }

        private void OnSelectedTrainsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            ErrorMessage = string.Empty;
        }
    }
}
