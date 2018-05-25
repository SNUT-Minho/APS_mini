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
        [Route("api/Product/{productNumber}")]
        public Product Get(int productNumber)
        {
            Product p = productRepo.GetProductByProductNumber(productNumber);
            var result = productRepo.GetProductData(p);

            return result;
        }

        // GET: api/Product/5
        [Route("api/Product/{groupUID}/{productGroupID}/{productSubGroupID}/{productTypeID}/{UID}")]
        public IEnumerable<Product> Get(int groupUID, int productGroupID, int productSubGroupID, int productTypeID, int UID)
        {
            Product p = new Product();
            p.GroupUID = groupUID;
            p.ProductGroupID = productGroupID;
            p.ProductSubGroupID = productSubGroupID;
            p.ProductTypeID = productTypeID;
            p.UID = UID;

            var result = productRepo.GetAllProduct(p);
            return result;
        }


        // POST: api/Product
        public Product Post([FromBody]Product product)
        {
            var result = productRepo.CreateProduct(product);

            return result;
        }

        // PUT: api/Product/5
        [Route("api/Product/{groupUID}/{pid}/{rid}")]
        public void Put(int groupUID, int pid, int rid)
        {
            productRepo.updateRouting(groupUID, pid, rid);
        }

        // DELETE: api/Product/5
        [Route("api/Product/{id}")]
        public int Delete(int id)
        {
            var result = productRepo.RemoveProduct(id);

            return result;
        }
    }
}
