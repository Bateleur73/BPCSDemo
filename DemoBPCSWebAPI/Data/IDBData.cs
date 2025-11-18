
namespace DemoBPCSWebAPI.Data
{
    public interface IDBData
    {
        List<Booking> Bookings { get; set; }
        List<Location> Locations { get; set; }
        List<Vehicle> Vehicles { get; set; }
    }
}