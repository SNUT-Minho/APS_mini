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
    public class RoutingController : ApiController
    {
        RoutingRepo routingRepo = new RoutingRepo();

        // GET: api/Routing
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Routing/5
        public IEnumerable<Routing> Get(int id)
        {
           var result = routingRepo.getAllRoutingLst(id);
           return result;
        }

        // GET: api/Routing/5
        [Route("api/Routing/{groupUID}/{rid}")]
        public IEnumerable<Routing> Get(int groupUID, int rid)
        {
            var result = routingRepo.getAllRoutingMember(rid);
            return result;
        }

        /// <summary>
        /// -1 : Start Node
        /// -99: End Node
        /// </summary>
        /// <param name="routings"></param>
        // POST: api/Routing
        public void Post(List<Routing> routings)
        {
            foreach (var node in routings)
            {
                string sourceId = node.SourceID;
                if(sourceId != null)
                {
                    var length = sourceId.Length - 1;
                    var ren = length - 3;
                    var id = sourceId.Substring(4, ren);

                    if(id == "start")
                    {
                        node.SourceWID = -1;
                    }else if(id == "end")
                    {
                        node.SourceWID = -99;
                    }
                    else
                    {
                        node.SourceWID = Convert.ToInt32(id);
                    }
                }

                string targetId = node.TargetID;
                if(targetId != null)
                {
                    var length = targetId.Length - 1;
                    var ren = length - 3;
                    var id = targetId.Substring(4, ren);

                    if (id == "start")
                    {
                        node.TargetWID = -1;
                    }
                    else if (id == "end")
                    {
                        node.TargetWID = -99;
                    }
                    else
                    {
                        node.TargetWID = Convert.ToInt32(id);
                    }
                    routingRepo.createNewRoutingConnection(node);
                }
                else
                {
                    routingRepo.createNewRoutingNode(node);
                }
            }
        }

        // PUT: api/Routing/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Routing/5
        public void Delete(int id)
        {
        }
    }
}
