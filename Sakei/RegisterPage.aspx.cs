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
        AccountManager _mgr = new AccountManager;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            




        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            model.Account = this.txtAcc.Text.Trim();
            model.PWD = this.txtPWD.Text.Trim();
            model.Mail = this.txtMail.Text.Trim();

            if (this.rdomale.Checked)
                model.sex = "男";
            else
                model.sex = "女";

            _mgr.CreateAccount(model);
        }
    }
}