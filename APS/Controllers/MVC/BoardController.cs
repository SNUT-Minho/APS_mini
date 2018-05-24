using APS.Models.Repositories;
using APS.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Controllers
{
    public class BoardController : Controller
    {
        ProductRepository productRepo = new ProductRepository();
        RoutingRepo routingRepo = new RoutingRepo();

        static int count = 0;
        // GET: Board
        public ActionResult Index()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return RedirectPermanent("/Board/Schedule");
        }

        public ActionResult Schedule()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        public ActionResult Order()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        public ActionResult LineCapacity()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        public ActionResult Worker()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Routing(int? routingNumber)
        {
            
            //로그인 안한 사용자 Redirect
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }
   
            if(routingNumber== null)
            {
                routingNumber = 0;
            }

            count++;
            return View(routingNumber);
        }

        public ActionResult WorkStation()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        public ActionResult Product()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        [HttpGet]
        public ActionResult BOM(int? productNumber)
        {
            Product result;
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }
            if(productNumber == null)
            {
                result  = new Product();
            }
            else
            {
                int ProductNumber = (int) productNumber;
                Product p = productRepo.GetProductByProductNumber(ProductNumber);
                result = productRepo.GetProductData(p);
            }

            return View(result);
        }

        //public ActionResult Memo()
        //{
        //    // 로그인 안한 사용자 Redirect 
        //    if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
        //    {
        //        TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
        //        return RedirectPermanent("~/");
        //    }

        //    return View();
        //}
    }
}