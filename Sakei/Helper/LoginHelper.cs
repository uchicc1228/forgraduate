﻿using SaKei.Models;
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
        /// <summary>
        /// 取得儲存於cookie中的使用者ID
        /// </summary>
        /// <returns></returns>
        public static Guid? GetUserID()
        {
                           
            var identity = HttpContext.Current.User.Identity as FormsIdentity;
            var ticket = identity.Ticket;

            if (Guid.TryParse(ticket.UserData, out var guid))
            {
                return guid;
            }
            else
            {
                return null;
            }
        }
       
        public static void Login(string account, string UserID)
        {

            bool isPersistence = false;
            TimeSpan timeout = new TimeSpan(3, 0, 0);

            FormsAuthentication.SetAuthCookie(account, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
             (

                1,
                account,
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
            HttpContext.Current.Response.Cookies.Add(loginCookie);

        }


        public static void Logout()
        {
            FormsAuthentication.SignOut();

        }
    }
}