using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class Routing
    {
        public int GroupUID { get; set; }

        public int RID { get; set; }
        public string RoutingName { get; set; }

        // item + id 로 넘어온것을 변환
        public string SourceID { get; set; }
        public string TargetID { get; set; }

        public int SourceWID { get; set; }
        public int TargetWID { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}