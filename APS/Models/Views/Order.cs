using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class Order
    {
        public int OId { get; set; } // Order Number
        public int GroupUID { get; set; }
        public int ProductNumber { get; set; }
        public string RoutingName { get; set; }
        public string Description { get; set; }
        public int LotSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CriticalRatio { get; set; }
        public string UserName { get; set; }
        public int AllowWorkStationGroup { get; set; }
        public string Note { get; set; }
    }
}