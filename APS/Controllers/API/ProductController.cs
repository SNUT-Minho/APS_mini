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
    public class ProductController : ApiController
    {
        ProductRepository productRepo = new ProductRepository();

        // GET: api/Product
        public void Get()
        {
            return;
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/Product
        public Product Post([FromBody]Product product)
        {
            var result = productRepo.CreateProduct(product);

            return result;
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
