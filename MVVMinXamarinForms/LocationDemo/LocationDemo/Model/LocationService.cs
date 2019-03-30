using Xamarin.Essentials;
namespace LocationDemo.Model
{
    public class LocationService : ILocationService
    {
        public bool LocationStatus;

        public bool IsLocationEnabled()
        {
            bool locationEnabled = false;

            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = Geolocation.GetLocationAsync(request);

            if (location != null)
                locationEnabled = true;

            return locationEnabled;
        }
    }
}
