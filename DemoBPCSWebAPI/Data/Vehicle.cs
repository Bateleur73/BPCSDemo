using System.Reflection;

namespace DemoBPCSWebAPI.Data
{
    public class Vehicle
    {
        public string Registration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double DailyRate { get; set; }
        public int LocationID { get; set; }

        public Vehicle()
        {
            Registration = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            DailyRate = 0;
            LocationID = 0;
        }

        public Vehicle(string registration, string manufacturer, string model, double dailyRate, int location)
        {
            Registration = registration;
            Manufacturer = manufacturer;
            Model = model;
            DailyRate = dailyRate;
            LocationID = location;
        }
    }
}
