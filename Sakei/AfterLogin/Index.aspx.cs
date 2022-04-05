using Sakei.Helper;
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
        private Guid _userID;
        private UserModel _model;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region "cc"
            string q1 = Request.QueryString["msg"];
            if (!String.IsNullOrEmpty(q1))
            {
                Response.Write($"<script>alert('{q1}')</script>");
            }
            #endregion

            #region "RYU"
            _userID = (Guid)LoginHelper.GetUserID();
            _model = _umgr.GetUserData(_userID,out bool isFirstLogin);
            if (isFirstLogin)
            {
                Response.Redirect("../ExamSystem/ExamLevelCheckMode.aspx");
            }
            this.lblName.Text = _model.UserName;

            this.lblRank.Text = _model.UserPoints.ToString();
            this.lblLevel.Text = _model.UserLevel.ToString();
            this.lblMoney.Text = _model.UserMoney.ToString();
            this.picCharacter.ImageUrl = _model.Character;
            #endregion
        }

        protected void btnChCharacter_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserCharacterChange.aspx");
        }

        protected void btnInfoCh_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserPWDChange.aspx");
        }
    }
}