using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace APS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //[!] ASP.NET 4.5 이상에서 유효성 검사 컨트롤 사용하기
            //[1] PM> Install-Package jQuery
            //[2] PM> Install-Package AspNet.ScriptManager.jQuery
            //[3] Global.asax - Application_Start()
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode =
                System.Web.UI.UnobtrusiveValidationMode.WebForms;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //[DevStateManagement] 응용 프로그램이 시작될 때 실행되는 코드입니다.
            Application["Now"] = DateTime.Now;
        }

        protected void Application_End() {
           
        }

        void Session_Start(object sender, EventArgs e)
        {
            // 세션 유지시간 2시간
            Session.Timeout = 60;

            // 로그인 후에 해당 사용자의 정보 값으로 대체
            Session["UID"] = 1;
            Session["UserID"] = "abc";
            Session["UserName"] = "이민호";
            Session["CompanyName"] = "서울과기대";

            //[DevStateManagement] 새 세션이 시작할 때 실행되는 코드입니다.
            Session["Now"] = DateTime.Now;
        }

        // ASP.NET MVC Manual Configuration in Global.asax - Localization
        void Application_BeginRequest(object sender, EventArgs e)
        {
            //var culture = new CultureInfo("en-US"); // 특정 언어로 시작하고자할 때에 값을 지정
            var culture = CultureInfo.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
