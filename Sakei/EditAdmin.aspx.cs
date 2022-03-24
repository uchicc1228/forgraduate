using Sakei.Helper;
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
    public partial class EditAdmin : System.Web.UI.Page
    {
        AdminAccountModel modelAdmin = new AdminAccountModel();
        AdminAccountManager _mgr_Admin = new AdminAccountManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.ltlmsg.Text = "<b>密碼設定原則，須包含以下四點<br/>" + "1.含英文大寫及小寫字元<br/>" + "2.含至少一位數字<br/>" + "3.長度至少八碼，最長20碼 <br/>"  + "4.可含特殊字元(#?!@$%^&*-) <br/>";

            }
            
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            modelAdmin.Account = this.txtAcc.Text.Trim();
            //帳號

            if (modelAdmin.Account.Length < 8 || modelAdmin.Account.Length > 20)
            {
                Response.Write("<script>alert('請注意帳號長度，須為８～２０字元')</script>");
                return;
            }

            if (_mgr_Admin.GetAccount(modelAdmin.Account) != null)
            {
                Response.Write("<script>alert('存在相同帳號!')</script>");
                return;
            }

             modelAdmin.PWD = this.txtPWD.Text.Trim();
            //密碼
            if (!_mgr_Admin.isValidPWD(modelAdmin.PWD))
            {
                Response.Write("<script>alert('請注意密碼格式')</script>");
                return;
            }

          
            if (modelAdmin.PWD.Length < 8 || modelAdmin.PWD.Length > 20)
            {
                Response.Write("<script>alert('請注意密碼長度，須為８～２０字元')</script>");
                return;
            }

            
            //信箱
            modelAdmin.Mail = this.txtMail.Text.Trim();
            if (!_mgr_Admin.isValidEmail(modelAdmin.Mail))
            {
                Response.Write("<script>alert('請注意信箱格式')</script>");
                return;
            }
            //產生GUID以及雜湊後的密碼，鹽
           modelAdmin = PWDHash.AdminHash(modelAdmin);
            //管理者等級
           modelAdmin.Level= Convert.ToInt32(this.intLevel.SelectedValue);
           //使用者姓名
           modelAdmin.Name= this.txtName.Text.Trim();
            //存入資料庫
            _mgr_Admin.CreateAdminAccounthash(modelAdmin);

                Response.Write("<script>alert('新增成功!!')</script>");

        }

    }
}