using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using LocationDemo.Model;

namespace LocationDemo.ViewModel
{
    public class SecondPageViewModel : BaseViewModel
    {
        #region Properties

        private string _locationStatus;
        public string LocationStatus
        {
            get
            {
                return _locationStatus;
            }
            set
            {
                _locationStatus = value;
                RaiseOnPropertyChanged("LocationStatus");
            }
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        { 
            get
            {
                return _welcomeMessage;
            }
            set
            {
                _welcomeMessage = value;
                RaiseOnPropertyChanged("WelcomeMessage");
            }
        }

        public ICommand OpenMainPageCommand { get; set; }

        public ICommand ShowLocationStatus { get; set; }

        public ICommand ClearLocationStatus { get; set; }

        private readonly INavigationService _navigationService;

        private readonly ILocationService _locationService;

        #endregion

        public SecondPageViewModel(INavigationService navigationService, ILocationService locationService)
        {
            _navigationService = navigationService;
            _locationService = locationService;

            OpenMainPageCommand = new Command(OpenPreviousPage);
            ShowLocationStatus = new Command(LocationStatusResult);
            ClearLocationStatus = new Command(ClearLocation);
        }

        private void OpenPreviousPage()
        {
            var viewModel = new MainPageViewModel(_navigationService, _locationService);
            _navigationService.OpenNewPage(viewModel);
            
        }

        private void LocationStatusResult()
        {
            DisplayLocationStatus(_locationService.IsLocationEnabled());
        }

        private void DisplayLocationStatus(bool status)
        {
            if (status)
                this.LocationStatus = "Location Enabled";
            else
                this.LocationStatus = "Location Disabled";
        }

        private void ClearLocation()
        {
            LocationStatus = string.Empty;
        }

    }
}
