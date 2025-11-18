namespace DemoBPCSWebAPI.Data
{
    public class Booking
    {
        public string BookingCode { get; set; } = "";
        public int LocationID { get; set; } = 0;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerSurname { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string VehicleReg { get; set; } = string.Empty;
        public double BookingRate { get; set; } = 0;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
    }
}
