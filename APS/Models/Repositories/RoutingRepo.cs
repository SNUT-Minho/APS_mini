using APS.Models.Views;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APS.Models.Repositories
{
    public class RoutingRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    

        public Routing getRouting(int groupUID, int productNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", groupUID);
            parameters.Add("@ProductNumber", productNumber);

            var result = db.Query<Routing>("GetRouting", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            return result;
        }

        public void DeleteRouting(int rid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RID", rid);

            var result = db.Query<Routing>("DeleteRouting", parameters, commandType: CommandType.StoredProcedure).ToList();
          
        }


        public IEnumerable<Routing> getAllRoutingConnection(int rid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RID", rid);

            var result = db.Query<Routing>("GetAllRoutingConnection", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }


        public IEnumerable<Routing> getAllRoutingMember(int rid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RID", rid);

            var result = db.Query<Routing>("GetAllRoutingMember", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public IEnumerable<Routing> getAllRoutingLst(int groupUid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", groupUid);

            var result = db.Query<Routing>("GetAllRoutingLst", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public void updateRoutingInfo(Routing routing)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SourceWID", routing.SourceWID);
            parameters.Add("@RID", routing.RID);
            parameters.Add("@ProcessingTime", routing.ProcessingTime);
            parameters.Add("@SetupTime", routing.SetupTime);
            parameters.Add("@Cycle", routing.Cycle);

            db.Execute("UpdateRoutingInfo", parameters, commandType: CommandType.StoredProcedure);
        }

        public void createNewRoutingNode(Routing routing)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", routing.GroupUID);
            parameters.Add("@RoutingName", routing.RoutingName);
            parameters.Add("@SourceWID", routing.SourceWID);
            parameters.Add("@X", routing.X);
            parameters.Add("@Y", routing.Y);
            parameters.Add("@ProcessingTime", routing.ProcessingTime);
            parameters.Add("@SetupTime", routing.SetupTime);
            parameters.Add("@Cycle", routing.Cycle);

            db.Execute("CreateRouting", parameters, commandType: CommandType.StoredProcedure);

        }

        public void createNewRoutingConnection(Routing routing)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RoutingName", routing.RoutingName);
            parameters.Add("@SourceWID", routing.SourceWID);
            parameters.Add("@TargetWID", routing.TargetWID);

            db.Execute("AddConnectionToRouting", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}