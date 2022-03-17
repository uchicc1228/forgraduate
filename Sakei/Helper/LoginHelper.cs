using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Sakei.Helper
{
    public class LoginHelper
    {

        public static bool IsLogined()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["??"];
            if (loginCookie != null)
                return true;
            else
            {
                return false;
            }
        }


        public static string GetAccount()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["??"];
            if (loginCookie == null)
                return null;

            var account = loginCookie[Utility.UserStatusUtility.NormalMemberCookie];
            return account;
        }

        public static int? GetUserLevel()
        {
            var loginCookie = HttpContext.Current.Request.Cookies["??"];
            if (loginCookie == null)
                return null;
            var userLevel = loginCookie[Utility.UserStatusUtility.AdminCookie];
            if (!int.TryParse(userLevel, out var temp))
                return null;
            else
                return temp;
        }

        public static void Login(AccountModel model, string UserID)
        {

            bool isPersistence = false;
            TimeSpan timeout = new TimeSpan(3, 0, 0);

            FormsAuthentication.SetAuthCookie(model.Account, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
             (

                1,
                model.Account,
                DateTime.Now,
                DateTime.Now.Add(timeout),
                isPersistence,
                UserID
                );

            //設定目前登入者至COOKIE

            string cookiename = FormsAuthentication.FormsCookieName;
            string encryptedText = FormsAuthentication.Encrypt(ticket);
            HttpCookie loginCookie = new HttpCookie(cookiename, encryptedText);
            loginCookie.HttpOnly = true;
            loginCookie.Expires = DateTime.Now.Add(timeout);
            HttpContext.Current.Response.Cookies.Add(loginCookie);

            //設定目前登入者至current user

            FormsIdentity identity = new FormsIdentity(ticket);
            GenericPrincipal gp = new GenericPrincipal(identity, new string[] { });
            HttpContext.Current.User = gp;
            
        }


        public static void Logout()
        {
           FormsAuthentication.SignOut();
        }
    }
}