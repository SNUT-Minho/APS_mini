using APS.Models.Repositories;
using APS.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APS.Controllers.API
{
    public class ScheduleController : ApiController
    {
        ScheduleRepository scheduleRepo = new ScheduleRepository();
        // GET: api/Schedule
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Schedule/5
        [Route("api/Schedule/{groupUID}/{start}")]
        public IEnumerable<Schedule> Get(int groupUID, DateTime start)
        {
            DateTime s = start.AddHours(8);
            DateTime e = start.AddHours(21);

           var result= scheduleRepo.GetAllSchedule(groupUID, s, e);

           return result;
        }

        // POST: api/Schedule
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Schedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Schedule/5
        public void Delete(int id)
        {
        }
    }
}
