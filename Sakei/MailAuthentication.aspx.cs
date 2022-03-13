using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei
{
    public partial class MailAuthentication : System.Web.UI.Page
    {
        AccountModel model = new AccountModel();
        AccountManager _mgr = new AccountManager();


        protected void Page_Load(object sender, EventArgs e)
        {

            NameValueCollection collection = this.Request.QueryString;
            Guid id1 = Guid.Parse(collection[0]) ;
            AccountModel _id = _mgr.GetAccount(id1);
            this.ltl1.Text = "您的使用者帳號為" + _id.Account;
           
             

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            AccountModel model = new AccountModel();
            NameValueCollection collection = this.Request.QueryString;
            model.ID = Guid.Parse(collection[0]);
            

            string newpwd1 = this.txtpw1.Text.Trim();
            string newpwd2 = this.txtpw2.Text.Trim();
           
            if (string.Compare(newpwd1, newpwd2) == 0)
            {
                 model.PWD = newpwd1;
                _mgr.UpdatePwd(model);
            };
        }
    }
}