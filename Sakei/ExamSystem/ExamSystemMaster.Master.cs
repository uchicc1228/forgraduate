using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ExamSystem
{
    public partial class ExamSystemMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判斷是否已登入
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~//LoginPage.aspx");
            }

            //判斷等級是否符合


        }
        protected void btnGiveUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }
    }
}