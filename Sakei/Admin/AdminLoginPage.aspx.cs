using Sakei.Helper;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei
{
    public partial class AdminLoginPage : System.Web.UI.Page
    {

        private AdminAccountManager _mgr = new AdminAccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {


            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();
            bool activestatue = (_mgr.GetActiveorNot(account));
           //檢查帳號是否啟用
            if (activestatue != true)
            {
                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
                return;
            }

            AdminAccountModel acc = _mgr.GetAccount(account);
            if (acc == null)
            {
                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
                return;
            }
            else
            {
                pwd = PWDHash.LoginHashAdmin(pwd, acc);
            }

            if (this._mgr.TryLogin(account, pwd))
            {
                AdminAccountModel acc1 = _mgr.GetAccount(account);
                LoginHelper.Login(acc1.Account, Convert.ToString(acc1.ID));
                Response.Redirect("AdminMainPage.aspx");
            }
            else
            {

                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
            }
        }
        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    LoginHelper.Logout();
        //    Response.Redirect(Request.RawUrl);
        //}

        protected void forgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPage.aspx");
        }
    }
}