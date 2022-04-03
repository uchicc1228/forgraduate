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

namespace Sakei.AfterLogin
{
    public partial class UserPWDChange : System.Web.UI.Page
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
        protected void btnPWDyes_Click(object sender, EventArgs e)
        {
            //先去確認第一個原密碼對不對 再來比對新密碼跟原密碼是否相同
            string oldpwd = this.txtpwdOld.Text.Trim();
            string newpwd = this.txtpwdNew.Text.Trim();
            string newpwd2 = this.txtpwdNew2.Text.Trim();

            //舊的密碼套用方法使其雜湊化
            UserModel id = _mgr.GetAccount(_userID);
            oldpwd = PWDHash.LoginHash(oldpwd, id);

            //用此密碼查庫        
            //查得到的話將新密碼雜湊後丟入改密碼
            _model = _mgr.GetPWD(oldpwd);

            if (!_mgr.isValidPWD(newpwd))
            {
                Response.Write("<script>alert('請注意密碼格式！')</script>");
            }
            else if (_model.PWD == oldpwd && newpwd == newpwd2)
            {
                _model.PWD = newpwd;
                _model = PWDHash.UpdateHash(_model);
                _mgr.UpdatePwd(_model);
                Response.Write("<script>alert('已變更成功!!')</script>");

                this.txtpwdOld.Text = string.Empty;
                this.txtpwdNew.Text = string.Empty;
                this.txtpwdNew2.Text = string.Empty;
            }
            else if (newpwd != newpwd2)
            {
                Response.Write("<script>alert('確認新密碼不相同，請再確認一次!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('原密碼錯誤，請再確認一次!!')</script>");
            }

        }

        protected void btnNICKyes_Click(object sender, EventArgs e)
        {
            string newName = this.txtname.Text.Trim();
            _model = _umgr.GetUserName(_userID);
            if (!string.IsNullOrWhiteSpace(newName) && _model.UserName != newName)
            {
                _model.UserName = newName;
                _umgr.UpdateUserName(_model);
                Response.Write("<script>alert('更新成功!!')</script>");
                this.lblName.Text = newName;
                this.txtname.Text = string.Empty;
            }
            else if (_model.UserName == newName)
            {
                Response.Write("<script>alert('暱稱相同，請重新輸入!!')</script>");
                return;
            }
            else
            {
                Response.Write("<script>alert('暱稱空白，請重新輸入!!')</script>");
                return;
            }
        }

        protected void btnInfoCh_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserPWDChange.aspx");
        }

        protected void btnChCharacter_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("UserCharacterChange.aspx");
        }
    }
}