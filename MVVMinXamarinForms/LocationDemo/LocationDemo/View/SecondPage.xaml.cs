using System;
using System.Collections.Generic;
using LocationDemo.Model;
using LocationDemo.ViewModel;
using Xamarin.Forms;

namespace LocationDemo.View
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            //BindingContext = new SecondPageViewModel(new NavigationService(), new LocationService());
            InitializeComponent();
        }
    }
}
