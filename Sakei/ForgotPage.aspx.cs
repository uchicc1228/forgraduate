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
    public partial class ForgotPage : System.Web.UI.Page
    {
        private AccountManager _mgr = new AccountManager();
        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string account = this.txtAcc.Text.Trim();
            string email = this.txtMail.Text.Trim();

    
            int activestatue = (_mgr.GetActiveorNot(account));
            if (activestatue != 1)
            {
                Response.Write("<script>alert('查無此帳號')</script>");
                return;
            }


            if (this._mgr.ForgotEmail(account, email))
            {
                try
                {
                    UserModel id = _mgr.GetAccount(account);
                    Response.Write("<script>alert('已發送驗證信!!')</script>");
                    _mgr.SendEmail(id.ID,id.Mail);
                    

                }
               catch(Exception ex)
                {
                    Logger.WriteLog("", ex);
                }
               
            }

            else
            {
                this.lbl.Text = "無此帳號/信箱";
            }

            
        }
    }
}