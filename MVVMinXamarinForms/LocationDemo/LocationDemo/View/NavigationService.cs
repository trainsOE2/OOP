using System;
using System.Collections.Generic;
using System.Reflection;
using LocationDemo.Model;
using LocationDemo.ViewModel;
using Xamarin.Forms;

namespace LocationDemo.View
{
    public class NavigationService : INavigationService
    {
        Dictionary<Type, Type> viewModels;
        Type viewModelType;


        public NavigationService()
        {
            viewModels = new Dictionary<Type, Type>();
            viewModels.Add(typeof(MainPageViewModel), typeof(MainPage));
            viewModels.Add(typeof(SecondPageViewModel), typeof(SecondPage));
        }

        public void OpenNewPage(object viewModel)
        {
            viewModelType = viewModel.GetType();

            if (viewModels.ContainsKey(viewModelType))
            {
                var viewType = viewModels[viewModelType];

                ContentPage page = (ContentPage)Activator.CreateInstance(viewType);
                page.BindingContext = viewModel;


                if (viewModel.GetType() == typeof(MainPageViewModel))
                    Application.Current.MainPage.Navigation.PopAsync();
                else
                    Application.Current.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                throw new Exception("Page Not Found");
            }
        }
    }
}

