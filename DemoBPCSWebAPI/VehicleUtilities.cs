using DemoBPCSWebAPI.Data;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace DemoBPCSWebAPI
{
    public class VehicleUtilities(IDBData db)
    {
        private readonly IDBData _db = db;

        public List<Vehicle> GetVehiclesForLocation(int locID)
        {
            List<Vehicle> result = [];

            foreach (var vehicle in _db.Vehicles) 
            { 
                if (vehicle.LocationID == locID)
                {
                    // check if the vehicle is already booked

                    if (!VehicleBooked(vehicle.Registration, DateTime.Now, DateTime.Now))
                    {
                        Vehicle temp = new()
                        {
                            LocationID = locID,
                            Registration = "",
                            Manufacturer = vehicle.Manufacturer,
                            Model = vehicle.Model,
                            DailyRate = vehicle.DailyRate
                        };

                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        private Boolean VehicleBooked(string vehReg, DateTime startDate, DateTime endDate)
        {
            foreach (var booking in _db.Bookings)
            {
                if (booking.VehicleReg == vehReg)
                {
                    for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
                    {
                        if (DateInRange(booking.StartDate, booking.EndDate, day))
                        {
                            return true;
                        }
                    }
                }
            } 

            return false;
        }

        private Boolean DateInRange(DateTime? startDate, DateTime? endDate, DateTime value)
        {
            return (startDate <= value) && (value <= endDate);
        }
    }
}
