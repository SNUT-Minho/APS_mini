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

        public IEnumerable<Memo> GetAllMemos(int groupUID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", groupUID);
            var result = db.Query<Memo>("GetAllMemos", parameters ,commandType: CommandType.StoredProcedure);

            return result;
        }

        public void DeleteMemo(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id", id);
            db.Execute("DeleteMemo", parameters, commandType: CommandType.StoredProcedure);
        }

        public Memo CreateMemo(Memo memo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", memo.Title);
            parameters.Add("@Description", memo.Description);
            parameters.Add("@UID", memo.UID);
            parameters.Add("@GroupUID", memo.GroupUID);

            parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@CreatedTime", dbType: DbType.DateTime, direction: ParameterDirection.Output);

            db.Execute("CreateMemo", parameters, commandType: CommandType.StoredProcedure);

            memo.CreatedTime = parameters.Get<DateTime>("@CreatedTime");
            memo.Id = parameters.Get<int>("@Id");

            return memo;
        }

        public void UpdateMemo(Memo memo)
        {
            string[] arr = memo.Title.Split(',');


            for (int i = 0; i < arr.Length; i++)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", arr[i]);
                parameters.Add("@ViewOrder", i);
                parameters.Add("@UID", memo.UID);
                db.Execute("UpdateMemoOrder", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}