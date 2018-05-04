using APS.Models.Repositories;
using APS.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace APS.Controllers.API
{
    public class BOMController : ApiController
    {
        ProductRepository productRepo = new ProductRepository();

        // GET: api/BOM
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BOM/5
        public IEnumerable<BOM> Get(int id)
        {
            var result = productRepo.GetAllBOM(id);

            return result;
        }

        // POST: api/BOM
        
        public void Post(List<BOM> bomLst)
        {
            int i = 1;
            foreach (var item in bomLst)
            {
                if(i == 1)
                {
                    productRepo.DeletBOM(item);
                    i++;
                }
                productRepo.CreateBOM(item);
            }
        }

        // PUT: api/BOM/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BOM/5
        public void Delete(int id)
        {
        }
    }
}
