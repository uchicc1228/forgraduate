using Sakei.Helper;
using Sakei.Manager;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei
{
    public partial class MallPage : System.Web.UI.Page
    {
        AccountManager _mgr = new AccountManager();
        UserManager _umgr = new UserManager();
        private Guid _userID;
        private UserModel _model;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userID = (Guid)LoginHelper.GetUserID();

            _model = _umgr.GetUserName(_userID);
            this.lblName.Text = _model.UserName;

            this.lblRank.Text = _model.UserPoints.ToString();
            this.lblLevel.Text = _model.UserLevel.ToString();
            this.lblMoney.Text = _model.UserMoney.ToString();
            this.picCharacter.ImageUrl = _model.Character;
        }

        protected void btnLV1_Click(object sender, EventArgs e)
        {

        }

        protected void btnLV2_Click(object sender, EventArgs e)
        {

        }

        protected void btnLV3_Click(object sender, EventArgs e)
        {

        }

        protected void btnLV4_Click(object sender, EventArgs e)
        {

        }

        protected void btnLV5_Click(object sender, EventArgs e)
        {

        }
    }
}