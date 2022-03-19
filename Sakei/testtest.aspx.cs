using Sakei.Helper;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated )
            {
                string userAccount = HttpContext.Current.User.Identity.Name;
                var identity = HttpContext.Current.User.Identity as FormsIdentity;
                this.ltl.Text ="您好"  + userAccount; 

            }

            else
            {

                this.ltl.Text = "未登入";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            LoginHelper.Login("Admin", "User001");
            Response.Redirect("BackForm\\Index.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect(Request.RawUrl);
        }
    }
}