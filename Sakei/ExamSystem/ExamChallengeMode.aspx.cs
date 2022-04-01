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
    public partial class ExamChallengeMode1 : System.Web.UI.Page
    {
        private AccountManager _accMgr = new AccountManager();

        public  UserModel User;
        public Guid UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = (Guid)LoginHelper.GetUserID();
            //取得使用者等級
            User = _accMgr.GetUserPointsAndMoney(UserID);


            

        }
    }
}