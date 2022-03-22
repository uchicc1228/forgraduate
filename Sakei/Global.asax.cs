using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Sakei
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var response = HttpContext.Current.Response;

            //if (request.RawUrl.Contains("/AfterLogin"))
            //{
            //    if (!request.IsAuthenticated)
            //    {

            //        //透過id 讀取資料庫 檢查level 
            //        response.Clear();
            //        response.StatusCode = 403;  //預計寫一個403網頁 或是defaulterror網頁
            //        response.Write("未授權");
            //        response.End();
            //    }
            //}



        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}