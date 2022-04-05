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
        public static void AdminLogin(string account, string AdminID)
        {

            bool isPersistence = false;
            TimeSpan timeout = new TimeSpan(3, 0, 0); //定義到期時間 HR,MIN,SEC

            FormsAuthentication.SetAuthCookie(account, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
             (

                1,//版本
                account,//使用者名稱
                DateTime.Now,//發行時間
                DateTime.Now.Add(timeout),// 有效期限
                isPersistence,//是否將 Cookie 設定成 Session Cookie，如果是則會在瀏覽器關閉後移除
                AdminID            //設定目前登入者至COOKIE

                );

           

            string cookiename = FormsAuthentication.FormsCookieName;
            
            string encryptedText = FormsAuthentication.Encrypt(ticket);//將 Ticket 加密
            HttpCookie AdminloginCookie = new HttpCookie(cookiename, encryptedText);//生成cookie
            AdminloginCookie.HttpOnly = true;//當 cookie 有設定 HttpOnly flag 時，瀏覽器會限制 cookie 只能經由 HTTP(S) 協定來存取
            AdminloginCookie.Expires = DateTime.Now.Add(timeout);//設定到期時間
            HttpContext.Current.Response.Cookies.Add(AdminloginCookie);//將 Ticket 寫入 Cookie

            //設定目前登入者至current User
            FormsIdentity identity = new FormsIdentity(ticket);// 根據ticket識別驗證票證。
            GenericPrincipal gp = new GenericPrincipal(identity, new string[] { });
            HttpContext.Current.User = gp;
            HttpContext.Current.Response.Cookies.Add(AdminloginCookie);

        }


        public static void Logout()
        {
            FormsAuthentication.SignOut();

        }
    }
}