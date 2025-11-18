using DemoBPCSWebAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoBPCSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDBData _db;

        public LocationController(IDBData db)
        {
            _db = db;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            List<string> temp = [];

            if (_db != null)
            {
                foreach (var item in _db.Locations)
                {
                    temp.Add($"{item.LocationName}");
                }
            }

            return temp;
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
