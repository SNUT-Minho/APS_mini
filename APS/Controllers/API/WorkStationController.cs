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
    public class WorkStationController : ApiController
    {
        WorkStationRepo workRepo = new WorkStationRepo();

        // GET: api/WorkStation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/WorkStation/5
        [Route("api/WorkStation/{id}/{pageCount}")]
        public IEnumerable<WorkStation> Get(int id, int pageCount)
        {
            var result = workRepo.GetAllWorkStation(id, pageCount);
            return result;
        }

        // POST: api/WorkStation
        public WorkStation Post(WorkStation workStation)
        {
            var result = workRepo.CreateWorkStation(workStation);
            return result;
        }

        // PUT: api/WorkStation/5
        [Route("api/WorkStation/{id}/{page}")]
        public void Put(int id, int page, WorkStation workStation)
        {
            workStation.GroupUID = id;
            workRepo.UpdateWorkStation(workStation, page);
        }

        // DELETE: api/WorkStation/5
        public void Delete(int id)
        {
            workRepo.DeleteWorkStationById(id);
            return;
        }
    }
}
