using APS.Models.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace APS.Models.Repositories
{
    public class ProductRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public IEnumerable<ProductGroup> GetAllProductGroup(int groupUID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", groupUID);  
            var result =  db.Query<ProductGroup>("GetAllProductGroup", parameters, commandType: CommandType.StoredProcedure);
            
            return result;
        }


        //internal IEnumerable<Product> GetAllProduct()
        //{
            
        //}



        public IEnumerable<ProductType> GetAllProductType(int groupUID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", groupUID);
            var result = db.Query<ProductType>("GetAllProductType", parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        public Product CreateProduct(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductGroupID", product.ProductGroupID);
            parameters.Add("@ProductNumber", product.ProductNumber);
            parameters.Add("@Description", product.Description);
            parameters.Add("@ProductTypeID", product.ProductTypeID);
            parameters.Add("@GroupUID", product.GroupUID);
            parameters.Add("@UID", product.UID);

            parameters.Add("@PID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ProductGroupName", dbType: DbType.String, direction: ParameterDirection.Output, size: 25 );
            parameters.Add("@ProductTypeName", dbType: DbType.String, direction: ParameterDirection.Output, size: 25 );

            var result = db.Execute("CreateProduct", parameters, commandType: CommandType.StoredProcedure);

            product.PID = parameters.Get<int>("@PID");
            product.ProductGroupName = parameters.Get<string>("@ProductGroupName");
            product.ProductTypeName = parameters.Get<string>("@ProductTypeName");

            return product;
        }
    }
}