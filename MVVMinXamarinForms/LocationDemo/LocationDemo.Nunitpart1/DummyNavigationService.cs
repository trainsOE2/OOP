﻿using LocationDemo.Model;

namespace LocationDemo.Nunitpart1
{
    public class DummyNavigationService : INavigationService
    {
        private object _viewModel;

        public void OpenNewPage(object obj)
        {
            _viewModel = obj.GetType();
        }

        public object GetTypeOfObject()
        {
            return _viewModel;
        }
    }
}
