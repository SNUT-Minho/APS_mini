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

        // [!!미적용!!] -- 회사명을 기존 데이터베이스 내에서 검색해서 일치하는게 있으면 해당 그룹으로 Group UID 를 넘겨주면 됨
        /// <summary>
        /// 만약 새로운 기업이면 해당 기업 명으로 Domain Group 생성 + Domain User 생성
        /// </summary>
    
        public int GroupUID { get; set; }
        public int SELECT_INDEX { get; set; }
        public string CompanyName { get; set; }   
                                                     
        public string UserName { get; set; }
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