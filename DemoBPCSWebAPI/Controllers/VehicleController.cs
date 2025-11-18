using DemoBPCSWebAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoBPCSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IDBData _db;

        public VehicleController(IDBData db)
        {
            _db = db;
        }

        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> temp = [];

            if (_db != null)
            {
                foreach (var item in _db.Vehicles)
                {
                    temp.Add($"{item.Manufacturer} - {item.Model} - {item.Registration}");
                }
            }
            return temp;
        }

        // GET api/<VehicleController>/5
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
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
