using APS.Models;
using APS.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace APS.Controllers
{
    public class AccountController : Controller
    {
        // USER 저장소 객체
        private UserRepository userRepo = new UserRepository();

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            Response.RedirectPermanent("/Account/Login");
            
            return View();
        }


        // 회원 가입 페이지
        [HttpGet]
        public ActionResult Register()
        {
            // empty

            return View();
        }

        // 회원 가입 로직
        [HttpPost]
        public ActionResult Register(User user)
        {
            userRepo.RegisterUser(user);
            return View("Greeting");
        }

        [HttpGet]
        public ActionResult Greeting()
        {
            return View();
        }


        // 로그인 페이지
        [HttpGet]
        public ActionResult Login()
        {
            // Empty
            return View();
        }

        // 로그인 로직
        [HttpPost]
        public ActionResult Login(string txtUserID, string txtPassword)
        {
            string originLastLoginIP;
            DateTime originLastLoginDate;
           
            int result = userRepo.LoginUser(txtUserID, txtPassword, Request.UserHostAddress.Replace("::1", "127.0.0.1"), out originLastLoginIP, out originLastLoginDate);

            if (result == 1)// 로그인 성공
            {
                var user = userRepo.GetUser(txtUserID);
                if(user != null)
                {
                    // 특정 사용자의 정보를 Application 전역 변수에 기록 (하나의 아이디가 여러번 로그인 되는 것을 방지)
                    System.Web.HttpContext.Current.Application.Lock();
                    System.Web.HttpContext.Current.Application["UserInfo@" + user.UserID] = Session.SessionID + "!" + Request.ServerVariables["REMOTE_HOST"];
                    System.Web.HttpContext.Current.Application.UnLock();

                    // 세션 변수에 사용자 정보를 저장
                    Session["UID"] = user.UID;
                    Session["UserID"] = user.UserID;
                    Session["CompanyName"] = user.CompanyName;
                    Session["UserName"] = user.UserName;
                }

                // 튕겨나온 페이지가 있다면, 로그인 후 해당 페이지로 다시 이동
                if (!String.IsNullOrEmpty(Request["ReturnUrl"]))
                {
                    Response.RedirectPermanent(Request["ReturnUrl"]);
                }

                return Redirect("/Board/Index");
            }
            else // 로그인 실패
            {
                TempData["msg"] = "<script>alert('아이디와 비밀번호를 확인해주세요');</script>";
               // Response.RedirectPermanent("/Account/Login");
            }

            return View();
        }
    }
}