
using LocationDemo.Model;
using LocationDemo.View;
using LocationDemo.ViewModel;
using Xamarin.Forms;

namespace LocationDemo
{
    public class App : Application
    {
        public App()
        {
            var startPage = new MainPage();
            startPage.BindingContext = new MainPageViewModel(new NavigationService(), new LocationService());
            MainPage = new NavigationPage(startPage);
        }
    }
}
