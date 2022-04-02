using Sakei.Helper;
using Sakei.Manager;
using Sakei.Models;
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
        ShoppingListManager _smgr = new ShoppingListManager();
        private Guid _userID = (Guid)LoginHelper.GetUserID();
        private UserModel _model;
        private int level;
        ShoppingListModel shoppingModel = new ShoppingListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _model = _umgr.GetUserName(_userID);
                this.lblName.Text = _model.UserName;

                this.lblRank.Text = _model.UserPoints.ToString();
                this.lblLevel.Text = _model.UserLevel.ToString();
                this.lblMoney.Text = _model.UserMoney.ToString();
                this.picCharacter.ImageUrl = _model.Character;

                #region "商城道具"
                string query = Request.QueryString["key"];
                if (!int.TryParse(query, out level))
                {
                    level = 5;
                }

                List<ItemModel> items;

                if (level != 0)
                {
                    items = _mmgr.GetItem(level);
                }
                else
                {
                    items = _mmgr.GetItem();
                }
                foreach (var item in items)
                {
                    item.Content = item.Content.Replace("~", "..");
                }

                this.rptItems.DataSource = items;
                this.rptItems.DataBind();

                #endregion

            }

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

        protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "BuyButton":
                    string[] arr = e.CommandArgument.ToString().Split(',');
                    shoppingModel.UserID = _userID;
                    Guid id;
                    Guid.TryParse(arr[0],out id);
                    shoppingModel.ItemID = id;
                    shoppingModel.Content = arr[1];
                    _smgr.CreateShoppingList(shoppingModel);

                    Response.Redirect(this.Request.RawUrl);
                    break;

                default:
                    break;
            }
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
           
        }
    }
}