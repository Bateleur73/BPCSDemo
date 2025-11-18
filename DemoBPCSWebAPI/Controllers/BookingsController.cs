using DemoBPCSWebAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoBPCSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IDBData _db;

        public BookingsController(IDBData db)
        {
            _db = db;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        //public IEnumerable<string> Get()
        public IEnumerable<Booking> Get()
        {
            return _db.Bookings;

        //    return new string[] { "value1", "value2" };
        }

/*
        [HttpGet("{location}")]
        public ActionResult<IEnumerable<Vehicle>> Get(string location)
        {
            LocationUtilities loc = new LocationUtilities(_db);
            int locID = loc.GetLocationID(location);

            List<Vehicle> vehicles = [];

            if (locID == -1)
            {
                // Error here
            }
            else
            {
                VehicleUtilities temp = new VehicleUtilities(_db);
                vehicles = temp.GetVehiclesForLocation(locID);
            }

            return Ok(vehicles);
        }*/

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            if (booking == null)
                return BadRequest("Booking is null");

            // Save to database
            BookingUtilities temp = new(_db);

            string bookingcode = temp.MakeBooking(booking);

            if ( bookingcode != "")
            {
                return Ok(new { message = $"Booking was successfully - Booking Code is {bookingcode} " });
            }
            else
            {
                return BadRequest("Booking confirmation failed");
            }
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
