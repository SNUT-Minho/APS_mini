using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Models.Views
{
    public class Product
    {
        // Product
        public int PID { get; set; }                                 // 자동 생성 일련번호

        public int ProductGroupID { get; set; }                      // 제품 그룹군 번호
        public string ProductGroupName { get; set; }                 // 제품 그룹군 이름 (EC-I/EC-FLAT/Bolt/Flange)

        public int ProductNumber { get; set; }                       // 실제 사용하는 번호
        public string Description { get; set; }                      // 품목 간단설명

        public int ProductTypeID { get; set; } = 1;                  // 완제품 =1 / 반제품 =2/ 원자재 =3 **Default 값들
        public string ProductTypeName { get; set; }      // 완제품 / 반제품 / 원자재


        public int GroupUID { get; set; }                           // 사용자 그룹(삼성 sds) 일련번호
        public int UID { get; set; }                                // 사용자 아이디 일련번호

        // DB에는 없음
        public List<Product> Products { get; set; }                 // 자식품목 리스트


        // BOM
        public int ParentNumber { get; set; } = 0;                   // 부모 품목 번호 ( 완 <- 반 <- 원)
        public int ProductOrder { get; set; }                        // 보여지는 순서
    }
}