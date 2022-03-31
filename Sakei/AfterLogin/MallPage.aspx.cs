using Sakei.Helper;
using Sakei.Manager;
using SaKei.Helpers;
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
        MallManager _mmgr = new MallManager();
        private Guid _userID;
        private UserModel _model;
        private int level;

        protected void Page_Load(object sender, EventArgs e)
        {
            _userID = (Guid)LoginHelper.GetUserID();

            _model = _umgr.GetUserName(_userID);
            this.lblName.Text = _model.UserName;

            this.lblRank.Text = _model.UserPoints.ToString();
            this.lblLevel.Text = _model.UserLevel.ToString();
            this.lblMoney.Text = _model.UserMoney.ToString();
            this.picCharacter.ImageUrl = _model.Character;

            string query = Request.QueryString["key"];
            if (!int.TryParse(query, out level))
            {
                level = 5;
            }

            List<ItemModel> items = _mmgr.GetItem(level);
            this.rptItems.DataSource = items;
            this.rptItems.DataBind();
        }

        protected void btnLV_Click(object sender, EventArgs e)
        {
            if (sender == this.btnLV1)
            {
                Response.Redirect("MallPage.aspx?key=1");
            }
            else if (sender == this.btnLV2)
            {
                Response.Redirect("MallPage.aspx?key=2");
            }
            else if (sender == this.btnLV3)
            {
                Response.Redirect("MallPage.aspx?key=3");
            }
            else if (sender == this.btnLV4)
            {
                Response.Redirect("MallPage.aspx?key=4");
            }
            else if (sender == this.btnLV5)
            {
                Response.Redirect("MallPage.aspx?key=5");
            }
            else if (sender == this.btnLV)
            {
                Response.Redirect("MallPage.aspx?key=0");
            }
        }
    }
}