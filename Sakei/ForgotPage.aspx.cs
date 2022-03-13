using DeliciousMap.Helpers;
using SaKei.Manager;
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
        private AccountManager _accMgr = new AccountManager();
        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string account = this.txtAcc.Text.Trim();
            string email = this.txtMail.Text.Trim();

            if (this._accMgr.ForgotEmail(account, email))
            {
                try
                {
                    _accMgr.SendEmail();
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