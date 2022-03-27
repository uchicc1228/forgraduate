using Sakei.Helper;
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
            _mgr.GetAccount(id1);
            this.ltlmsg.Text = "<b>密碼設定原則，須包含以下四點<br/>" + "1.含英文大寫及小寫字元<br/>" + "2.含至少一位數字<br/>" + "3.長度至少八碼，最長20碼 <br/>" + "4.可含特殊字元(#?!@$%^&*-) <br/>";

            

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            AccountModel model = new AccountModel();
            NameValueCollection collection = this.Request.QueryString;
            model.ID = Guid.Parse(collection[0]);
            

            string newpwd1 = this.txtpw1.Text.Trim();
            string newpwd2 = this.txtpw2.Text.Trim();
            
            if(_mgr.isValidPWD(newpwd1) == false)
            {
                Response.Write("<script>alert('請注意密碼格式!!')</script>");
                return;
            }




            if (string.Compare(newpwd1, newpwd2) == 0)
            {
              
                model.PWD = newpwd1;
                model = PWDHash.UpdateHash(model);                         
                _mgr.UpdatePwd(model);
                Response.Write("<script>alert('已變更成功!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('需輸入一樣的密碼!!')</script>");
            }
        }
    }
}