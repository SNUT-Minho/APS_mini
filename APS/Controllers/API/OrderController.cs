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
    public class OrderController : ApiController
    {
        OrderRepo orderRepo = new OrderRepo();

        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [Route("api/Order/{groupUID}/{start}/{end}")]
        public IEnumerable<Order> Get(int groupUID, DateTime start, DateTime end)
        {
            var result = orderRepo.getAllOrderLst(groupUID, start, end);

            return result;
        }

        // POST: api/Order
        [Route("api/Order")]
        public Order Post(Order order)
        {
            order.StartDate = Convert.ToDateTime(order.StartDate);
            order.EndDate = Convert.ToDateTime(order.EndDate);
            var result = orderRepo.createNewOrder(order);

            return result;
        }

        // POST: api/Order
        [Route("api/Order/{oid}")]
        // Update Order ?
        public void Post(int oid, Order order)
        {
            order.StartDate = Convert.ToDateTime(order.StartDate);
            order.EndDate = Convert.ToDateTime(order.EndDate);
            order.OId = oid;
            orderRepo.updateOrder(order);
        }


        // PUT: api/Order/5
        [Route("api/Order/{OId}")]
        public void Put(int OId, Note note)
        {
            orderRepo.updateNote(OId, note.script);
        }


        // DELETE: api/Order/5
        public void Delete(int id)
        {
            orderRepo.removeOrder(id);
        }
    }
}
