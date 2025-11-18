namespace DemoBPCSWebAPI.Data
{
    internal class CarInfo(string manufacturer, string model, double rate)
    {
        public string Manufacturer { get; set; } = manufacturer;
        public string Model { get; set; } = model;
        public double Rate { get; set; } = rate;
    }

    public class DBData : IDBData
    {
        public List<Vehicle> Vehicles { get; set; } = [];
        public List<Location> Locations { get; set; } = [];
        public List<Booking> Bookings { get; set; } = [];

        public DBData()
        {
            // Create Location data
            Location loc1 = new(1, "München");
            Location loc2 = new(2, "Stuttgard");
            Location loc3 = new(3, "Berlin");
            Location loc4 = new(4, "Hamburg");
            Location loc5 = new(5, "Frankfurt");

            string[] num = { "MUC", "S", "B", "HH", "F" };

            Locations.Add(loc1);
            Locations.Add(loc2);
            Locations.Add(loc3);
            Locations.Add(loc4);
            Locations.Add(loc5);

            List<CarInfo> tempVeh = [];
            CarInfo veh1 = new("VW", "Polo", 50.00);
            CarInfo veh2 = new("VW", "Golf", 60.00);
            CarInfo veh3 = new("Audi", "A4 Avant", 70.00);
            CarInfo veh4 = new("BMW", "318", 65.00);
            CarInfo veh5 = new("Mercedes", "V-Klasse", 95.00);
            tempVeh.Add(veh1);
            tempVeh.Add(veh2);
            tempVeh.Add(veh3);
            tempVeh.Add(veh4);
            tempVeh.Add(veh5);

            // Create Vehicle data
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Vehicle veh = new($"{num[i]} 000{j}", tempVeh[j].Manufacturer, tempVeh[j].Model, tempVeh[j].Rate, Locations[i].ID);
                    Vehicles.Add(veh);
                }
            }

            // Create Test Booking Data

            for (int i = 0; i < 5; i++)
            {
                Booking booking = new()
                {
                    LocationID = Locations[i].ID
                };
                booking.BookingCode = $"{booking.LocationID}-TEST-CODE";
                booking.CustomerName = "TestName";
                booking.CustomerSurname = "TestSurname";
                booking.CustomerPhone = "Test Phone";
                booking.Address = "Test Address";
                booking.CustomerEmail = "Test Email";
                booking.VehicleReg = $"{num[i]} 0000{booking.LocationID}";
                booking.BookingRate = 99.99;
                booking.StartDate = DateTime.Now;
                booking.EndDate = DateTime.Now;

                Bookings.Add(booking);
            }
        }
    }
}
