using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class Schedule
    {
        public int SId { get; set; }
        public int GroupUID { get; set; }
        public int OId { get; set; }
        public int WId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}