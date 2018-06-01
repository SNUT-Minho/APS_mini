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

        public WorkStationGroup CreateWorkStationGroup(WorkStationGroup workStationGroup)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", workStationGroup.GroupUID);
            parameters.Add("@WorkStationGroupTitle", workStationGroup.WorkStationGroupTitle);
            var WG = db.Query<WorkStationGroup>("CreateWorkStationGroup", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            return WG;
        }

        public void RemoveRoutingInfo(int Wid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@WID", Wid);
            var RID = db.Query<int>("GetRemoveRoutingNumber", parameters, commandType: CommandType.StoredProcedure).ToList();

            foreach (var rid in RID)
            {
                parameters = new DynamicParameters();
                parameters.Add("RID", rid);
                db.Execute("RemoveRoutingInfo", parameters, commandType:CommandType.StoredProcedure);
            }
        }

        public WorkStation CreateWorkStation(WorkStation workStation)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", workStation.Title);
            parameters.Add("@Image", workStation.Image);
            parameters.Add("@Description", workStation.Description);
            parameters.Add("@SetupTime", workStation.SetupTime);
            parameters.Add("@ProcessingTime", workStation.ProcessingTime);
            parameters.Add("@GroupUID", workStation.GroupUID);
            parameters.Add("@WorkStationGroupID", workStation.WorkStationGroupID);
            parameters.Add("@WId", dbType: DbType.Int32, direction: ParameterDirection.Output);
         

            db.Execute("CreateWorkStation", parameters , commandType: CommandType.StoredProcedure);
            workStation.WId = parameters.Get<int>("@WId");

            return workStation;
        }

        public void DeleteWorkStationById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@WId", id);
            db.Execute("DeleteWorkStation", parameters, commandType: CommandType.StoredProcedure);
        }



        public IEnumerable<WorkStationGroup> GetAllWorkStationGroupList(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", id);

            var result = db.Query<WorkStationGroup>("GetAllWorkStationGroupList", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public IEnumerable<WorkStation> GetAllWorkStationList(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", id);

            var result = db.Query<WorkStation>("GetAllWorkStationList", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
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
                parameters.Add("@WId", arr[i]);
                parameters.Add("@ViewOrder", i + (page*8));
                parameters.Add("@GroupUID", workStation.GroupUID);
                db.Execute("UpdateWorkStationOrder", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}