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
  
    public class MemoRepository
    {
        IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public IEnumerable<Memo> GetAllMemos()
        {
            var result = db.Query<Memo>("GetAllMemos", commandType: CommandType.StoredProcedure);

            return result;
        }

        public void DeleteMemo(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id", id);
            db.Execute("DeleteMemo", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}