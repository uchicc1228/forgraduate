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
       
        protected void Page_Init(object sender, EventArgs e)
        {
            //判斷是否已登入
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {

                Response.Redirect("~//LoginPage.aspx");

            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
           


        }
        protected void btnGiveUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AfterLogin/index.aspx");
        }
    }
}