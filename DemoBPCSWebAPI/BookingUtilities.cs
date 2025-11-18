using DemoBPCSWebAPI.Data;

namespace DemoBPCSWebAPI
{
    public class BookingUtilities(IDBData db)
    {
        private readonly IDBData _db = db;

        public string MakeBooking(Booking bookingInfo)
        {
            if (_db != null) 
            {
                bookingInfo.BookingCode = GenerateBookingCode(bookingInfo);
                _db.Bookings.Add(bookingInfo);
            }

            return bookingInfo.BookingCode;
        }

        private static string GenerateBookingCode(Booking bookingInfo)
        {            
            string dt = DateTime.Now.ToString("yyyyMMdd-HHmmsszzz");

            return $"{bookingInfo.LocationID}-{dt}-{bookingInfo.CustomerName[..1]}{bookingInfo.CustomerSurname[..1]}";
        }
    }


}
