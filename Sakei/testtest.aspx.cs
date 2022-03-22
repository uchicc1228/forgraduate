using Sakei.Helper;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei
{
    public partial class testtest : System.Web.UI.Page
    {
        AccountManager _mgr = new AccountManager();
        AccountModel model = new AccountModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userAccount = HttpContext.Current.User.Identity.Name;
                var identity = HttpContext.Current.User.Identity as FormsIdentity;
                this.ltl.Text = "您好" + userAccount;

            }

            else
            {

                this.ltl.Text = "未登入";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string acc = this.txtacc.Text.Trim();
            string pwd = this.txtpwd.Text.Trim();
            if (_mgr.TryLogin(acc, pwd))
            {
                AccountModel acc1 = _mgr.GetAccount(acc);
                LoginHelper.Login(acc1.Account, Convert.ToString(acc1.ID));
                Response.Redirect("AfterLogin\\Index.aspx");
            }
            else
            {
                this.ltl.Text = "帳號密碼錯誤";
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect(Request.RawUrl);
        }
    }
}