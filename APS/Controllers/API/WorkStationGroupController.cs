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
    public class WorkStationGroupController : ApiController { 
    
        WorkStationRepo workRepo = new WorkStationRepo();

        // GET: api/WorkStationGroup
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WorkStationGroup/5
        [Route("api/WorkStationGroup/{groupUID}")]
        public IEnumerable<WorkStationGroup> Get(int groupUID)
        {
            var result = workRepo.GetAllWorkStationGroupList(groupUID);
            return result;
        }

        // POST: api/WorkStationGroup
        public WorkStationGroup Post(WorkStationGroup workStationGroup)
        {
           var result =  workRepo.CreateWorkStationGroup(workStationGroup);
           return result;
        }

        // PUT: api/WorkStationGroup/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/WorkStationGroup/5
        public void Delete(int id)
        {
        }
    }
}
