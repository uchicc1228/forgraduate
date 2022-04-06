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
        UserManager _umgr = new UserManager();
        MallManager _mmgr = new MallManager();
        ShoppingListManager _smgr = new ShoppingListManager();
        private Guid _userID = (Guid)LoginHelper.GetUserID();
        private UserModel _model;
        private ShoppingListModel _shoppingModel;
        private int level;
        ShoppingListModel shoppingModel = new ShoppingListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _model = _umgr.GetUserData(_userID);
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
                    item.StyleContent = item.StyleContent.Replace("~", "..");
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

                    Guid id;
                    Guid.TryParse(arr[0], out id);
                    int price;
                    int.TryParse(arr[2], out price);
                    int level;
                    int.TryParse(arr[3], out level);

                    _model = _umgr.GetUserData(_userID);
                    _shoppingModel = _smgr.GetShoppingList_shoppingID(_userID, id);

                    if (_model.UserLevel > level)
                    {
                        Response.Write("<script>alert('等級不足無法購買衣服!!')</script>");
                        return;
                    }
                    else if (_shoppingModel != null)
                    {
                        Response.Write("<script>alert('無法購買相同的衣服!!')</script>");
                        return;
                    }
                    else if (_model.UserMoney < price)
                    {
                        Response.Write("<script>alert('金幣不足無法購買衣服!!')</script>");
                        return;
                    }
                    else
                    {
                        shoppingModel.UserID = _userID;
                        shoppingModel.ItemID = id;
                        shoppingModel.Content = arr[1];
                        _mmgr.UpdateUserMoney(_model, _userID, id);
                        _smgr.CreateShoppingList(shoppingModel);
                        Response.Write("<script>alert('購買成功，來去換新衣ㄅ!!');location.href='Index.aspx';</script>");
                    }
                    break;
                default:
                    break;
            }

        }
    }
}