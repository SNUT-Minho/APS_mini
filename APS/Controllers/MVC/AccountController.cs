using APS.Models;
using APS.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Controllers
{
    public class AccountController : Controller
    {
        // USER 저장소 객체
        private UserRepository user = new UserRepository();

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            Response.RedirectPermanent("/Account/Login");
            
            return View();
        }

        /// <summary>
        /// 사용자 계정 생성 창
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            
            return View();
        }


        /// <summary>
        ///  구현 예정 (새 계정 등록 로직 + DB연동)
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(User user)
        {
            UserRepository userRepo = new UserRepository();
            userRepo.RegisterUser(user);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string txtUserID, string txtPassword)
        {
            string originLastLoginIP;
            DateTime originLastLoginDate;
            // 여기서 로그인 처리해서 성공 1 이면 -> Redirect Board/Index
            // 실패시 -> 로그인 실패 Script 처리후 -> Redirect Account/Login
            int result = user.LoginUser(txtUserID, txtPassword, Request.UserHostAddress.Replace("::1", "127.0.0.1"), out originLastLoginIP, out originLastLoginDate);

            if (result == 1)// 로그인 성공
            {
                Response.RedirectPermanent("/Board/Index");
            }
            else // 로그인 실패
            {
                Response.RedirectPermanent("/Account/Login");
            }

            return View();
        }
    }
}