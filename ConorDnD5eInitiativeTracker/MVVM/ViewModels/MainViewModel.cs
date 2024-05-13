using System;
using ConorDnD5eInitiativeTracker.Core;

namespace ConorDnD5eInitiativeTracker.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand ScenarioBuilderViewCommand { get; set; }
        public RelayCommand CharacterBuilderViewCommand { get; set; }
        public RelayCommand InitiativeViewCommand { get; set; }
        public RelayCommand MonsterSearchViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }

        public ScenarioBuilderViewModel ScenarioBuilderVM { get; set; }
        public CharacterBuilderViewModel CharacterBuilderVM { get; set; }
        public InitiativeViewModel InitiativeVM { get; set; }
        public MonsterSearchViewModel MonsterSearchVM { get; set; }
        public HomeViewModel HomeVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            ScenarioBuilderVM = new ScenarioBuilderViewModel();
            CharacterBuilderVM = new CharacterBuilderViewModel();
            InitiativeVM = new InitiativeViewModel();
            MonsterSearchVM = new MonsterSearchViewModel();
            HomeVM = new HomeViewModel();

            CurrentView = HomeVM;

            ScenarioBuilderViewCommand = new RelayCommand(o =>
            {
                CurrentView = ScenarioBuilderVM;
            });

            CharacterBuilderViewCommand = new RelayCommand(o =>
            {
                CurrentView = CharacterBuilderVM;
            });

            InitiativeViewCommand = new RelayCommand(o =>
            {
                CurrentView = InitiativeVM;
            });

            MonsterSearchViewCommand = new RelayCommand(o =>
            {
                CurrentView = MonsterSearchVM;
            });

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
        }
    }
}
