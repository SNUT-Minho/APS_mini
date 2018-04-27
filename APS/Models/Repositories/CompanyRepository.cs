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
    public class CompanyRepository
    {

        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        // Company 목록 바인드용
        public IEnumerable<Company> getAllCompany()
        {
            var result = db.Query<Company>("GetAllCompany", commandType: CommandType.StoredProcedure);

            return result;
        }

        // 새로운 Company 추가
        public Company createCompany(Company company)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CompanyName", company.CompanyName);
            parameters.Add("@CID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@SecureCode", dbType: DbType.Int32, direction: ParameterDirection.Output);

            db.Execute("CreateCompany", parameters, commandType: CommandType.StoredProcedure);
            var cid = parameters.Get<int>("@CID");
            var code = parameters.Get<int>("@SecureCode");

            company.CID = cid;
            company.SecureCode = code;

            return company;
        }

        // CID 값으로 CompanyName 읽어오기
        public string getCompany(int cid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CID", cid);
            var result = db.Query<string>("GetCompany", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            return result;
        }


        // CID 값으로 SecureCode 읽어오기
        public int getScureCode(int cid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CID", cid);
            var result = db.Query<int>("GetSecureCode", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            return result;
        }
    }
}