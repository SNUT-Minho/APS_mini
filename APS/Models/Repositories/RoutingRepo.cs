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

        public void createNewRoutingNode(Routing routing)
        {
            DynamicParameters parameters = new DynamicParameters();
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