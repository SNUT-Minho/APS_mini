using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models
{
    public class User
    {
        public User()
        {
            // Empty
        }

        public User(int uid)
        {
            this.UID = uid;
        }

        public int UID { get; set; }
        public string UserID { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
        public int VisitedCount { get; set; }
        public bool Blocked { get; set; }
    }
}