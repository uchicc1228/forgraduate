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
        protected void Page_Load(object sender, EventArgs e)
        {
            string q1 = Request.QueryString["msg"];
            Response.Write($"<script>alert('{q1}')</script>");
            Response.Write("<script>alert('驗證碼超過時效!!')</script>");
        }

        protected void btnInfoCh_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserPWDChange.aspx");
        }
   
    }
}