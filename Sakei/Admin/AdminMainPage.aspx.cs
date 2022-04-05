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

namespace Sakei
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        AdminAccountManager _mgr = new AdminAccountManager();
        AdminManager _umgr = new AdminManager();
        private Guid _userID;
        private AdminAccountModel _model;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblAdminLevel.Text = "";
            this.btnAdmin.Visible = false;
            this.lblEditAdmin.Visible = false;
            this.btnItem.Visible = false;
            this.lblEditItem.Visible = false;
            this.btnTest.Visible = false;
            this.lblEditTest.Visible = false;
            #region "Hans"
            _userID = (Guid)LoginHelper.GetUserID();
            _model = _umgr.GetAccount(_userID);
            this.lblAdminName.Text = _model.Name;
            int Level = Convert.ToInt32(_model.Level);



            if (Level == (int)AdminLevelEnum.admin)
            {

                this.lblAdminLevel.Text = "管理員";
                this.btnAdmin.Visible = true;
                this.lblEditAdmin.Visible = true;
                this.btnItem.Visible = true;
                this.lblEditItem.Visible = true;
                this.btnTest.Visible = true;
                this.lblEditTest.Visible = true;

            }
            else if (Level == (int)AdminLevelEnum.manager)
            {
                this.lblAdminLevel.Text = "主管";
                this.btnAdmin.Visible = true;
                this.lblEditAdmin.Visible = true;
                this.btnItem.Visible = true;
                this.lblEditItem.Visible = true;
                this.btnTest.Visible = true;
                this.lblEditTest.Visible = true;

            }


            else if (Level == (int)AdminLevelEnum.employee)
            {
                this.lblAdminLevel.Text = "員工";
                this.btnItem.Visible = true;
                this.lblEditItem.Visible = true;
                this.btnTest.Visible = true;
                this.lblEditTest.Visible = true;
            }
            else this.lblAdminLevel.Text = "未知的身分";
            #endregion
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EditAdmin.aspx");
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EditTest.aspx");

        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EditItem.aspx");

        }
    }
}