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
    //寫Login 配合今天上課的glbol 在golbol上面做驗證登入
    public partial class LoginPage : System.Web.UI.Page
    {
       
            
        private AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginHelper.IsLogined())
            {
                var account = LoginHelper.GetAccount();
                var userlevel = LoginHelper.GetUserLevel();
                this.ltlMessage.Text = account;
                if (userlevel == 1)
                    this.ltlMessage.Text = "會員";
                else
                    this.ltlMessage.Text = "管理員";
            }
            else
                this.ltlMessage.Text = "上未登入";




            //    if (this._mgr.IsLogined())
            //{
            //    this.plcUserInfo.Visible = true;
            //    this.plcLogin.Visible = false;

            //    AccountModel account = this._mgr.GetCurrentUser();
            //    this.ltlAccount.Text = account.Account;
            //}
            //else
            //{
            //    this.plcLogin.Visible = true;
            //    this.plcUserInfo.Visible = false;
            //}
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginHelper.Login("Admin", 2);
            Response.Redirect(Request.RawUrl);


            //string account = this.txtAccount.Text.Trim();
            //string pwd = this.txtPassword.Text.Trim();

            //if (this._mgr.TryLogin(account, pwd))
            //{
            //    //Response.Redirect("~/BackAdmin/Index.aspx");
            //    Response.Redirect(Request.RawUrl);

            //}
            //else
            //{
            //    this.ltlMessage.Text = "登入失敗，請檢查帳號密碼。";
            //}
        }

        //登出紐



        protected void forgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPage.aspx");
        }
    }
}