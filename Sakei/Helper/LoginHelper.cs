using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Helper
{
    public class LoginHelper
    {

        public static bool IsLogined()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["System"];
            if(loginCookie != null)
                return true;
            else
            {
                return false;
            }
        }


        public static string GetAccount()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["System"];
            if(loginCookie == null)
                return null;

            var account = loginCookie[Utility.UserStatusUtility.NormalMemberCookie];
                return account;
        }

        public static int? GetUserLevel()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["System"];
            if (loginCookie == null)
                return null;
            var userLevel = loginCookie[Utility.UserStatusUtility.AdminCookie];
            if(!int.TryParse(userLevel, out var temp))
                return null;
            else
                return temp;
        }

        public static void Login (string account, int level)
        {
            var logincookie = new HttpCookie("System");

            logincookie.Values.Add(Utility.UserStatusUtility.NormalMemberCookie,account);

            logincookie.Values.Add(Utility.UserStatusUtility.AdminCookie,level.ToString());

            logincookie.Expires = DateTime.Now.AddDays(1);

            HttpContext.Current.Response.Cookies.Add(logincookie);
        }


        public static void Logout()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["System"];
            if(loginCookie != null)
            {
                loginCookie.Expires = DateTime.Now.AddDays(-2);
                loginCookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Add(loginCookie);
            }
        }
    }
}