
using BlazorBPCS.Components.DataModels;
using static System.Net.WebRequestMethods;

namespace BlazorBPCS.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _http;

        public LocationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<string>> GetLocationsAsync()
        {
            return await _http.GetFromJsonAsync<List<string>>("Location");
        }

        public async Task<List<VehicleInfo>> GetVehiclesForLocation(string locationName)
        {
            return await _http.GetFromJsonAsync<List<VehicleInfo>>($"Vehicle/{locationName}");
        }

        public async Task<HttpResponseMessage> Sendbooking(Booking booking)
        {
            return await _http.PostAsJsonAsync("bookings", booking);
        }

        public async Task<List<Booking>> GetMyBookings()
        {
            return await _http.GetFromJsonAsync<List<Booking>>("bookings");
        }
    }
}
