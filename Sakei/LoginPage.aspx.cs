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
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

            }
            else
                this.ltlMessage.Text = "尚未登入";




      
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginHelper.Login("Admin", "USER-001");
            Response.Redirect(Request.RawUrl);
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect(Request.RawUrl);

        }



        protected void forgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPage.aspx");
        }
    }
}