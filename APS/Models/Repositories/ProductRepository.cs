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

        public IEnumerable<ProductGroup> GetAllProductGroup(ProductGroup productGroup)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", productGroup.GroupUID);
            parameters.Add("@ParentProductGroupID", productGroup.ParentProductGroupID);
            
            var result =  db.Query<ProductGroup>("GetAllProductGroup", parameters, commandType: CommandType.StoredProcedure);
            
            return result;
        }


        public IEnumerable<Product> GetAllProduct(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", product.GroupUID);
            parameters.Add("@ProductGroupID", product.ProductGroupID);
            parameters.Add("@ProductSubGroupID", product.ProductSubGroupID);
            parameters.Add("@ProductTypeID", product.ProductTypeID);

            var result = db.Query<Product>("GetAllProduct", parameters, commandType: CommandType.StoredProcedure);
            foreach (var p in result)
            {
                p.ProductGroupName = db.Query<String>(@"Select ProductGroupName From ProductGroup Where ProductGroupID = @ProductGroupID ;", p ).SingleOrDefault();
                p.ProductSubGroupName = db.Query<String>(@"Select ProductGroupName From ProductGroup Where ProductGroupID = @ProductSubGroupID ;", p).SingleOrDefault();
                p.ProductTypeName = db.Query<String>(@"Select ProductTypeName From ProductType Where ProductTypeID = @ProductTypeID ;", p).SingleOrDefault();
                p.CreateUserName  = db.Query<String>(@"Select UserName From Domains Where UID = @UID ;", p).SingleOrDefault();
            }

            return result;
        }



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
            parameters.Add("@ProductSubGroupID", product.ProductSubGroupID);
            parameters.Add("@ProductNumber", product.ProductNumber);
            parameters.Add("@Description", product.Description);
            parameters.Add("@ProductTypeID", product.ProductTypeID);
            parameters.Add("@GroupUID", product.GroupUID);
            parameters.Add("@UID", product.UID);

            parameters.Add("@PID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ProductGroupName", dbType: DbType.String, direction: ParameterDirection.Output, size: 25 );
            parameters.Add("@ProductSubGroupName", dbType: DbType.String, direction: ParameterDirection.Output, size: 25);
            parameters.Add("@ProductTypeName", dbType: DbType.String, direction: ParameterDirection.Output, size: 25 );
            parameters.Add("@CreateUserName", dbType: DbType.String, direction: ParameterDirection.Output, size: 25);

            var result = db.Execute("CreateProduct", parameters, commandType: CommandType.StoredProcedure);

            product.PID = parameters.Get<int>("@PID");
            product.ProductGroupName = parameters.Get<string>("@ProductGroupName");
            product.ProductSubGroupName = parameters.Get<string>("@ProductSubGroupName");
            product.ProductTypeName = parameters.Get<string>("@ProductTypeName");
            product.CreateUserName = parameters.Get<string>("@CreateUserName");

            return product;
        }

        public ProductGroup CreateProductGroup(ProductGroup productGroup)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductGroupName", productGroup.ProductGroupName);
            parameters.Add("@GroupUID", productGroup.GroupUID);
            parameters.Add("@ProductGroupID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ParentProductGroupID", productGroup.ParentProductGroupID);

            db.Execute("CreateProductGroup",parameters, commandType : CommandType.StoredProcedure);
            productGroup.ProductGroupID = parameters.Get<int>("@ProductGroupID");
            return productGroup;
        }


        public ProductType CreateProductType(ProductType productType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductTypeName", productType.ProductTypeName);
            parameters.Add("@GroupUID", productType.GroupUID);
            parameters.Add("@ProductTypeID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            db.Execute("CreateProductType", parameters , commandType: CommandType.StoredProcedure);
            productType.ProductTypeID = parameters.Get<int>("@ProductTypeID");
            return productType;
        }
    }
}