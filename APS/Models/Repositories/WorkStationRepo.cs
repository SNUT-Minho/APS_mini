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
    public class WorkStationRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public WorkStation CreateWorkStation(WorkStation workStation)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", workStation.Title);
            parameters.Add("@Image", workStation.Image);
            parameters.Add("@Description", workStation.Description);
            parameters.Add("@SetupTime", workStation.SetupTime);
            parameters.Add("@ProcessingTime", workStation.ProcessingTime);
            parameters.Add("@GroupUID", workStation.GroupUID);
            parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            db.Execute("CreateWorkStation", parameters , commandType: CommandType.StoredProcedure);
            workStation.Id = parameters.Get<int>("@Id");

            return workStation;
        }

        public void DeleteWorkStationById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            db.Execute("DeleteWorkStation", parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<WorkStation> GetAllWorkStation(int id, int pageCount)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", id);
            parameters.Add("@PageCount", pageCount);

            var result = db.Query<WorkStation>("GetAllWorkStation", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public void UpdateWorkStation(WorkStation workStation, int page)
        {
            string[] arr = workStation.Title.Split(',');


            for (int i = 0; i < arr.Length; i++)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", arr[i]);
                parameters.Add("@ViewOrder", i + (page*8));
                parameters.Add("@GroupUID", workStation.GroupUID);
                db.Execute("UpdateWorkStationOrder", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}