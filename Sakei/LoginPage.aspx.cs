using Sakei.Helper;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaKei
{
 
    public partial class LoginPage : System.Web.UI.Page
    {
        private AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["prevUrl"] = Request.UrlReferrer.ToString();
                string urll = ViewState["prevUrl"].ToString();
                if (urll.Contains("/AfterLogin"))
                {

                    LoginHelper.Logout();
                   
                }
            }
            else
            {
                return;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {





            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();
            int activestatue = (_mgr.GetActiveorNot(account));
            if (activestatue != 1)
            {
                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
                return;
            }

            UserModel acc = _mgr.GetAccount(account);
            if (acc == null)
            {
                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
                return;
            }
            else
            {
                pwd = PWDHash.LoginHash(pwd, acc);
            }

            if (this._mgr.TryLogin(account, pwd))
            {    
                UserModel acc1 = _mgr.GetAccount(account);
                LoginHelper.Login(acc1.Account, Convert.ToString(acc1.ID));
                Response.Redirect("AfterLogin\\Index.aspx");
            }
            else
            {
               
                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
            }
        }
        protected void forgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPage.aspx");
        }


    }
}