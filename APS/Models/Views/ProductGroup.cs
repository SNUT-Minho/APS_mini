using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class ProductGroup
    {
        public int ProductGroupID { get; set; }         // 품목 번호
        public string ProductGroupName { get; set; }    // 품목 이름
        public int ParentProductGroupID { get; set; }   // 부모 품목 그룹
        public int GroupUID { get; set; }               // 회사 그룹 아이디

        // DB에는 없음
        public List<ProductGroup> ProductGroups { get; set; }
    }
}