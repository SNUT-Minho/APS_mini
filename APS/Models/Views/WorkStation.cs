using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class WorkStation
    {
        public int Id { get; set; }

        public String Title { get; set; }
        public String Image { get; set; }
        public String Description { get; set; }
        public int MyProperty { get; set; }
        public int SetupTime { get; set; }
        public int ProcessingTime { get; set; }

        public int VeiwOrder { get; set; }
        public int GroupUID { get; set; }
    }
}