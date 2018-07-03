using APS.Models.Views;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APS.Controllers.API
{

    public class DataController : ApiController
    {

        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        // GET: api/Data
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Data/5
        public ArrayList Get(int id)
        {
            ArrayList tooltip = new ArrayList();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OId", id);
            var order = db.Query<Order>("GetOrder", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            var lotSize = order.LotSize;

            parameters = new DynamicParameters();
            parameters.Add("@ParentProductNumber", order.ProductNumber);
            var products = db.Query<BOM>("GetAllProductLstByOfOrder", parameters, commandType: CommandType.StoredProcedure).ToList();
            
            
            foreach (var item in products)
            {
                ToolTip t = new ToolTip();
                t.count = (item.Count * lotSize);
                t.productNumber = item.ChildProductNumber;

                parameters = new DynamicParameters();
                parameters.Add("@ProductNumber", item.ChildProductNumber);
                string des = db.Query<string>("GetProductDescription", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                t.Description = des;
                tooltip.Add(t);
            }
    
            return tooltip;
        }

        // POST: api/Data
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
        }
    }
}
