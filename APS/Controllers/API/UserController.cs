using Dapper;
using System;
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
    public class UserController : ApiController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public bool Get(string id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", id);
            parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);

            db.Open();

            db.Execute("CheckUserID", parameters, commandType: CommandType.StoredProcedure);
            var result = parameters.Get<int>("@Result");

            db.Close();

            if(result == 0)
            {   
                // 동일한 아이디 없음.
                return true;
            }
            else
            {
                // 동일 아이디 존재
                return false;
            }
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
