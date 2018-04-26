using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Index()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                
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

        public ActionResult Routing()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
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

        public ActionResult BOM()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }

        public ActionResult Memo()
        {
            // 로그인 안한 사용자 Redirect 
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            return View();
        }
    }
}