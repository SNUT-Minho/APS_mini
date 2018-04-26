using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class Memo
    {
        public int Id { get; set; }
        public int UID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public int ViewOrder { get; set; }
    }
}