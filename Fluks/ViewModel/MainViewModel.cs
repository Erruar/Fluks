using Fluks.Core; 
namespace Fluks.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        private HomeViewModel HomeVm{ get; set; }
        private DiscoveryViewModel DiscoveryVm { get; set; }
        private SettingsViewModel SettingsVm { get; set; }
        private object _currentView;
        public object CurrentView
        {  
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }
        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            DiscoveryVm = new DiscoveryViewModel();
            SettingsVm = new SettingsViewModel();
            CurrentView = HomeVm;
            //Кнопка главной страницы (TestProperty.Req1)
            HomeViewCommand = new RelayCommand(o => 
            { 
                CurrentView = HomeVm;
            });
            //Кнопка страницы пресетов (TestProperty.Req2)
            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVm;
            });
            //Кнопка страницы настроек (TestProperty.Req3)
            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVm;
            });
        }
    }
}
