using BlazorBPCS.Components.DataModels;

namespace BlazorBPCS.Services
{
    public interface ILocationService
    {
        Task<List<string>> GetLocationsAsync();
        Task<List<VehicleInfo>> GetVehiclesForLocation(string locationName);
        Task<HttpResponseMessage> Sendbooking(Booking booking);
        Task<List<Booking>> GetMyBookings();
    }
}
