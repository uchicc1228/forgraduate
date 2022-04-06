using Sakei.Helper;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ExamSystem
{
    public partial class ExamLevelCheckMode : System.Web.UI.Page
    {
        private AccountManager _accMgr = new AccountManager();

        public UserModel UserData;
        public Guid UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string q1 = Request.QueryString["msg"];
            if (!String.IsNullOrEmpty(q1))
            {
                Response.Write($"<script>alert('{q1}')</script>");
            }
            UserID = (Guid)LoginHelper.GetUserID();
            //取得使用者等級
            UserData = _accMgr.GetUserPointsAndMoney(UserID);
        }
    }
}