using Sakei.Manager;
using Sakei.Models;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.AfterLogin
{
    public partial class Index : System.Web.UI.Page
    {
        AccountManager _mgr = new AccountManager();
        UserManager _umgr = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string q1 = Request.QueryString["msg"];
            if(!String.IsNullOrEmpty(q1))
            {
                Response.Write($"<script>alert('{q1}')</script>");
            }

            string name="";
            UserModel model = _umgr.GetUserName(name);
            this.lblName.Text = model.UserName;

            this.lblRank.Text = "000";
            this.lblLevel.Text = "000";
            this.lblMoney.Text = "000";

        }

        protected void btnInfoCh_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserPWDChange.aspx");
        }
   
    }
}