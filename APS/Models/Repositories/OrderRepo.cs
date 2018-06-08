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
    public class OrderRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public void updateOrder(Order order)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", order.GroupUID);
            parameters.Add("@OId", order.OId);
           
            parameters.Add("@LotSize", order.LotSize);
            parameters.Add("@StartDate", order.StartDate);
            parameters.Add("@EndDate", order.EndDate);
            parameters.Add("@CriticalRatio", order.CriticalRatio);
            parameters.Add("@UserName", order.UserName);
            parameters.Add("@AllowWorkStationGroup", order.AllowWorkStationGroup);

            var result = db.Execute("UpdateOrder", parameters, commandType: CommandType.StoredProcedure);

        }

        public void removeOrder(int oid)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OId", oid);

            db.Execute("RemoveOrder", parameters, commandType: CommandType.StoredProcedure);
        }

        public void updateNote(int oid, string note)
        {
            if(note == "null")
            {
                note = "";
            }

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OId", oid);
            parameters.Add("@Note", note);


            db.Execute("UpdateNote", parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Order> getAllOrderLst(int groupUID, DateTime startDate, DateTime endDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", groupUID);
            parameters.Add("@StartDate", startDate);
            parameters.Add("@EndDate", endDate);

            var result = db.Query<Order>("GetAllOrderLst", parameters, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public Order createNewOrder(Order order)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GroupUID", order.GroupUID);
            parameters.Add("@RoutingName", order.RoutingName);
            parameters.Add("@ProductNumber", order.ProductNumber);
            parameters.Add("@LotSize", order.LotSize);
            parameters.Add("@StartDate", order.StartDate);
            parameters.Add("@EndDate", order.EndDate);
            parameters.Add("@CriticalRatio", order.CriticalRatio);
            parameters.Add("@UserName", order.UserName);
            parameters.Add("@AllowWorkStationGroup", order.AllowWorkStationGroup);

            var result = db.Query<Order>("CreateNewOrder", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return result;
        }
    }
}