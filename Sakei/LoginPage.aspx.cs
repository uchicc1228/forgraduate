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
       
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();

            if (this._mgr.TryLogin(account, pwd))
            {
                
                Response.Redirect("BackForm/Index.aspx");

            }
            else
            {
                this.ltlMessage.Text = "登入失敗，請檢查帳號密碼。";
            }
        }

        //登出紐

        protected void forgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPage.aspx");
        }
    }
}