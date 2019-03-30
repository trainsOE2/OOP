using System.Windows.Input;
using Xamarin.Forms;
using LocationDemo.Model;

namespace LocationDemo.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {

        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaiseOnPropertyChanged("Name");
            }
        }
        
        private INavigationService _navigationService;

        private ILocationService _locationService;

        public ICommand NavigationCommand { get; set; }

        #endregion


        public MainPageViewModel(INavigationService navigationService, ILocationService locationService)
        {
            _navigationService = navigationService;
            _locationService = locationService;
            NavigationCommand = new Command(OpenNextPage);
        }

        private void OpenNextPage()
        {
            var viewModel = new SecondPageViewModel(_navigationService, _locationService);
            viewModel.WelcomeMessage = "Welcome " + Name;
            _navigationService.OpenNewPage(viewModel);
            Name = string.Empty;
        }
    }
}
