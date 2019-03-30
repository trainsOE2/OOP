using System;
using LocationDemo.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;//MS Test from Microsoft
//Nunit

namespace LocationDemo.UnitTests
{
    [TestClass]
    public class MainPageVMTest
    {
        [TestMethod]
        public void when_open_next_command_is_issued_then_app_moves_to_second_pages()
        {
            var dummyNavigationService = new DummyNavigationService();
            var dummyLocationService = new DummyLocationService();
            var mainPageViewModel = new MainPageViewModel(dummyNavigationService, dummyLocationService);

            var canOpenNextPage = mainPageViewModel.NavigationCommand.CanExecute(null);
            mainPageViewModel.NavigationCommand.Execute(null);

            Assert.AreEqual(true, canOpenNextPage, "The command is disabled to go to next page");
            Assert.AreEqual(typeof(SecondPageViewModel), dummyNavigationService.GetTypeOfObject());
        }
    }
}
