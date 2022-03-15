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
    public partial class RegisterPage : System.Web.UI.Page
    {
        AccountModel model = new AccountModel();
        AccountManager _mgr = new AccountManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlmsg.Text = "<b>密碼設定原則，須包含以下四點<br/>" + "1.含英文大或小寫字元<br/>" + "2.含數字<br/>" + "3.長度至少八碼，最長20碼 <br/>";

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            
            model.Account = this.txtAcc.Text.Trim();
            if(model.Account.Length < 8 ||  model.Account.Length > 20)
            {
                Response.Write("<script>alert('請注意帳號長度，須為８～２０字元')</script>");
                return;
            }

            model.PWD = this.txtPWD.Text.Trim();
            if (model.PWD.Length < 8 || model.PWD.Length > 20)
            {
                Response.Write("<script>alert('請注意密碼長度，須為８～２０字元')</script>");
                return;
            }


            model.Mail = this.txtMail.Text.Trim();
            if(!_mgr.isValidEmail(model.Mail))
            {
                Response.Write("<script>alert('請注意信箱格式')</script>");
                return;
            }


            if (_mgr.GetAccount(model.Account) != null)
            {
                Response.Write("<script>alert('存在相同帳號!')</script>");
                return;
            }
           

            //修正此處 產生一組變數 帶到信封內 然後填上確認身分 compare == 0 ~ 
            if(_mgr.CreateAccount(model))
            {
                Random rnd = new Random(GetHashCode());
                _mgr.SendEmail(model.Mail, rnd);
                Response.Write("<script>alert('已發送驗證信!!')</script>");
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}