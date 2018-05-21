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

        public void createNewRoutingNode(Routing routing)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", routing.GroupUID);
            parameters.Add("@RoutingName", routing.RoutingName);
            parameters.Add("@SourceWID", routing.SourceWID);
            parameters.Add("@X", routing.X);
            parameters.Add("@Y", routing.Y);

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