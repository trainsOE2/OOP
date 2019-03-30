using System;
using LocationDemo.Model;

namespace LocationDemo.UnitTests
{
    public class DummyLocationService : ILocationService
    {
        private bool _isLocatinoEnabled;
         
        public bool IsLocationEnabled()
        {
            return _isLocatinoEnabled;
        }

        public void SetLocation(bool isLocationEnabled)
        {
            _isLocatinoEnabled = isLocationEnabled;
            
        }
    }
}
