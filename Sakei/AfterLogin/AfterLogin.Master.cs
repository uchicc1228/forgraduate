using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//進入後先設定使用者的名字
//直接在這頁更改密碼 更改名字     更換裝備(maybe)
namespace Sakei.AfterLogin
{
    public partial class AfterLogin : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {

                Response.Redirect("~//LoginPage.aspx");

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}