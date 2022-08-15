using BLCinema;
using DALCinema;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApi.Controllers
{
    [Route("api/Schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private ScheduleBL bLSchedule;
        public ScheduleController(CinemaDbContext Context)
        {
            ScheduleBL bLSchedule = new ScheduleBL(Context);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Schedule> Get()
        {
            return bLSchedule.ListOfSchedules();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Post([FromBody] Schedule schedule, double price)
        {
            return bLSchedule.AddSchedule(schedule, price);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Schedule schedule)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
