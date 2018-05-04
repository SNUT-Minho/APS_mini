using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class BOM
    {
        public int BOM_ID { get; set; }
        public int ParentProductNumber { get; set; }
        public int ChildProductNumber { get; set; }
        public int Count { get; set; }
    }
}