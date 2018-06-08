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
        private CompanyRepository companyRepo = new CompanyRepository();

    

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

            // 회원가입 성공후 로그인 처리
            string originLastLoginIP;
            DateTime originLastLoginDate;

            userRepo.LoginUser(user.UserID, user.Password, Request.UserHostAddress.Replace("::1", "127.0.0.1"), out originLastLoginIP, out originLastLoginDate);

            // 특정 사용자의 정보를 Application 전역 변수에 기록 (하나의 아이디가 여러번 로그인 되는 것을 방지)
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["UserInfo@" + user.UserID] = Session.SessionID + "!" + Request.ServerVariables["REMOTE_HOST"];
            System.Web.HttpContext.Current.Application.UnLock();

            // 세션 변수에 사용자 정보를 저장
            Session["UID"] = user.UID;
            Session["GroupUID"] = user.GroupUID;
            Session["UserID"] = user.UserID;

            user.CompanyName = companyRepo.getCompany(user.GroupUID);
            Session["CompanyName"] = user.CompanyName;

            Session["UserName"] = user.UserName;
            Session["Industry"] = user.Industry;
            Session["Email"] = user.Email;

            return View("Greeting", user);
        }

        // 회원 가입 성공후 환영 페이지
        [HttpGet]
        public ActionResult Greeting(User user)
        {
            // 사용자 체크
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            user.UserName = Session["UserName"].ToString();

            return View(user);
        }

        // 로그아웃 페이지
        [HttpGet]
        public ActionResult Logout()
        {
            // 로직 처리후에 로그인 페이지로 이동
            // 사용자 체크
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }

            // 쿠키 제거
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Passwords"].Expires = DateTime.Now.AddDays(-1);

            // 어플리케이션 전역변수 제거 (동시 로그인 방지)
            System.Web.HttpContext.Current.Application["UserInfo@" + Session["UserID"].ToString()] = null;

            // 세션 정보 클리어
            Session.Abandon();

            // 기본 세션값으로 초기화
            Session.Timeout = 60;
            Session["UID"] = 1;
            Session["GroupUID"] = 1;
            Session["UserID"] = "abc";
            Session["UserName"] = "이민호";
            Session["CompanyName"] = "서울과기대";

            //[DevStateManagement] 새 세션이 시작할 때 실행되는 코드입니다.
            Session["Now"] = DateTime.Now;

            return RedirectPermanent("~/");
        }


        // 회원 탈퇴 페이지
        [HttpGet]
        public ActionResult UserDelete()
        {
            // 배포시 변경
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null || Session["UserID"].ToString() == "abc")
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("/Board/Index");
            }

            return View();
        }


        // 회원 탈퇴 페이지
        [HttpPost]
        public ActionResult UserDelete(User user)
        {
            // 사용자 체크
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null || Session["UserID"].ToString() == "abc")
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("/Board/Index");
            }

            var result = userRepo.DeleteUser(user);

            if (result > 0)
            {
                TempData["msg"] = "<script>alert('회원탈퇴 완료.');</script>";
                return RedirectPermanent("~/");
            }
            else
            {
                TempData["msg"] = "<script>alert('비밀번호를 확인해주세요.');</script>";
            }

            return View();
        }

        // 회원 정보 수정 페이지
        [HttpGet]
        public ActionResult UserInfo()
        {
            // 사용자 체크
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"] == null)
            {
                TempData["msg"] = "<script>alert('잘못된 접근경로입니다. 로그인 후 이용하세요.');</script>";
                return RedirectPermanent("~/");
            }
            else
            {
                string userId = Session["UserID"].ToString();
                User user = userRepo.GetUser(userId);
                user.CompanyName = companyRepo.getCompany(user.GroupUID);

                return View(user);
            }
        }


        // 회원 정보 수정 페이지
        [HttpPost]
        public ActionResult UserInfo(User user)
        {
            // 로그인 절차 후 모든 Default 페이지는 Greeting 페이지 / Redirect 된 페이지에 따라서 환영 문구 바꾸기
            userRepo.UpdateUser(user);
            TempData["msg"] = "<script>alert('회원정보 수정완료');</script>";

            return RedirectPermanent("/Account/UserInfo");
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
                if (user != null)
                {
                    // 특정 사용자의 정보를 Application 전역 변수에 기록 (하나의 아이디가 여러번 로그인 되는 것을 방지)
                    System.Web.HttpContext.Current.Application.Lock();
                    System.Web.HttpContext.Current.Application["UserInfo@" + user.UserID] = Session.SessionID + "!" + Request.ServerVariables["REMOTE_HOST"];
                    System.Web.HttpContext.Current.Application.UnLock();

                    // 세션 변수에 사용자 정보를 저장
                    Session["UID"] = user.UID;
                    Session["UserID"] = user.UserID;
                    Session["GroupUID"] = user.GroupUID;
                    Session["CompanyName"] = companyRepo.getCompany(user.GroupUID);
                    Session["UserName"] = user.UserName;
                    Session["Industry"] = user.Industry;
                    Session["Email"] = user.Email;
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

        
        public ActionResult TempUser()
        {

            // 세션 유지시간 2시간
            Session.Timeout = 60;

            // 로그인 후에 해당 사용자의 정보 값으로 대체
            Session["UID"] = 1;
            Session["GroupUID"] = 1;
            Session["UserID"] = "abc";
            Session["UserName"] = "이민호";
            Session["CompanyName"] = "서울과기대";

            //DevStateManagement] 새 세션이 시작할 때 실행되는 코드입니다.
            Session["Now"] = DateTime.Now;

            return Redirect("/Board/Schedule");
        }
    }
}