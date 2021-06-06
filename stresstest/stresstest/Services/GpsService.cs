using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace stresstest.Services
{
    public class GpsService
    {
       private CancellationTokenSource cts;

        public GpsService()
        {
        }

        public async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine($"{fnsEx}");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Console.WriteLine($"{fneEx}");
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine($"{pEx}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

    }
}
