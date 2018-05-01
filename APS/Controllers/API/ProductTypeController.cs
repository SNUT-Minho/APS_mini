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
    public class ProductTypeController : ApiController
    {
        ProductRepository productRepo = new ProductRepository();

        // GET: api/ProductType
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductType/5
        public IEnumerable<ProductType> Get(int id)
        {
            var result = productRepo.GetAllProductType(id);

            return result;
        }

        // POST: api/ProductType
        public ProductType Post([FromBody]ProductType productType)
        {
           var result =  productRepo.CreateProductType(productType);

            return result;
        }

        // PUT: api/ProductType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductType/5
        public void Delete(int id)
        {
        }
    }
}
