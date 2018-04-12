using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Controllers
{
    public class AccountController : Controller
    {
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
            Response.Write("등록");
            return View();
        }

        /// <summary>
        ///  구현 예정 (새 계정 등록 로직 + DB연동)
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string temp)
        {
            Response.Write("등록");
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string textUserID, string textPassword)
        {
            Response.RedirectPermanent("/Account/Register");

            return View();
        }
    }
}