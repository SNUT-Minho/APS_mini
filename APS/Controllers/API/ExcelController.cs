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
    public class ExcelController : ApiController
    {
        ProductRepository productRepo = new ProductRepository();

        // GET: api/Excel
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Excel/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/Excel
        public bool Post(List<Product> productLst)
        {
            foreach (var item in productLst)
            {
                int check = productRepo.checkProductNumber(item);
                if(check != 0)
                {
                    return false;
                }
            }
         

            foreach (var item in productLst)
            {   
                 productRepo.CreateProduct(item);
            }

            return true;
        }

        // PUT: api/Excel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Excel/5
        public void Delete(int id)
        {
        }
    }
}
