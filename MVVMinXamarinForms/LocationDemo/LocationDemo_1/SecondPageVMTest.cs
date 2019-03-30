using LocationDemo.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocationDemo.UnitTests
{
    [TestClass]
    public class SecondPageVMTest
    {
        [DataRow(true, "Location Enabled")]
        [DataRow(false, "Location Disabled")]
        [TestMethod]
        public void when_show_location_status_is_clicked_then_correct_location_status_is_displayed(bool isLocationEnabled, string message)
        {
            var dummyLocationService = new DummyLocationService();
            dummyLocationService.SetLocation(isLocationEnabled);
            var dummyNavigationService = new DummyNavigationService();
            var secondPageViewModel = new SecondPageViewModel(dummyNavigationService, dummyLocationService);

            var canShowLocationStatus= secondPageViewModel.ShowLocationStatus.CanExecute(null);
            secondPageViewModel.ShowLocationStatus.Execute(null);
            Assert.AreEqual(secondPageViewModel.LocationStatus, message);
        }

        [TestMethod]
        public void when_page_opens_then_no_location_status_is_displayed()
        {
            var dummyLocationService = new DummyLocationService();
            var dummyNavigationService = new DummyNavigationService();
            var mainPageViewModel = new MainPageViewModel(dummyNavigationService, dummyLocationService);

            var canOpenNextPage = mainPageViewModel.NavigationCommand.CanExecute(null);
            mainPageViewModel.NavigationCommand.Execute(null);

            var secondPageViewModel = new SecondPageViewModel(dummyNavigationService, dummyLocationService);

            Assert.IsTrue(string.IsNullOrEmpty(secondPageViewModel.LocationStatus));
        }

        [TestMethod]
        public void when_clear_button_is_clicked_then_location_status_is_an_empty_string()
        {
            var dummyLocationService = new DummyLocationService();
            var dummyNavigationService = new DummyNavigationService();
            var secondPageViewModel = new SecondPageViewModel(dummyNavigationService, dummyLocationService);

            var canShowLocationStatus = secondPageViewModel.ShowLocationStatus.CanExecute(null);
            secondPageViewModel.ShowLocationStatus.Execute(null);


            var canClearLocationStatus = secondPageViewModel.ClearLocationStatus.CanExecute(null);
            secondPageViewModel.ClearLocationStatus.Execute(null);

            Assert.IsTrue(string.IsNullOrEmpty(secondPageViewModel.LocationStatus));
        }

        [TestMethod]
        public void when_open_main_page_command_is_issued_then_main_page_is_displayed()
        {
            var dummyLocationService = new DummyLocationService();
            var dummyNavigationService = new DummyNavigationService();
            var secondPageViewModel = new SecondPageViewModel(dummyNavigationService, dummyLocationService);

            var canOpenPreviousPage = secondPageViewModel.OpenMainPageCommand.CanExecute(null);
            secondPageViewModel.OpenMainPageCommand.Execute(null);

            Assert.AreEqual(typeof(MainPageViewModel), dummyNavigationService.GetTypeOfObject());

        }
    }
}
