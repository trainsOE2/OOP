using LocationDemo.ViewModel;
using NUnit.Framework;

namespace LocationDemo.Nunitpart1
{
    [TestFixture]
    public class MainPageVMTest
    {
        [Test]
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
