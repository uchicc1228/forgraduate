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
    public partial class UserCharacterChange : System.Web.UI.Page
    {
        UserManager _umgr = new UserManager();
        MallManager _mmgr = new MallManager();
        ShoppingListManager _smgr=new ShoppingListManager();
        private Guid _userID;
        private UserModel _model;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userID = (Guid)LoginHelper.GetUserID();

            
            if(Guid.TryParse(this.Request.QueryString["item"],out Guid itemID))
            {
                _umgr.UpdateCharacter(_userID, itemID);
            }

            _model = _umgr.GetUserData(_userID);
            this.lblName.Text = _model.UserName;

            this.lblRank.Text = _model.UserPoints.ToString();
            this.lblLevel.Text = _model.UserLevel.ToString();
            this.lblMoney.Text = _model.UserMoney.ToString();
            this.picCharacter.ImageUrl = _model.Character;

            #region "鮭鮭換新衣"
            List<ShoppingListModel> items= _smgr.GetShoppingList(_userID);//呼叫購買的衣服
            foreach (var item in items)
            {
                item.Content = item.Content.Replace("~", "..");//取代文字
            }
            this.rptItems.DataSource = items;
            this.rptItems.DataBind();
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

        protected void btnCharacteryes_Click(object sender, EventArgs e)
        {

        }
    }
}