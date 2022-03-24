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
    public partial class Index : System.Web.UI.Page
    {
        AccountManager _mgr = new AccountManager();
        protected void Page_Load(object sender, EventArgs e)
        {
        

        }

        protected void btnInfoCh_Click(object sender, EventArgs e)
        {
            this.plcPWDChanger.Visible = true;
        }

        protected void btnPWDyes_Click(object sender, EventArgs e)
        {
            //先去確認第一個原密碼對不對 再來比對新密碼跟原密碼是否相同
            string oldpwd = this.txtpwdOld.Text.Trim();
            string newpwd  =this.txtpwdNew.Text.Trim();
            string newpwd2 = this.txtpwdNewx2.Text.Trim();
            AccountModel model  =   _mgr.GetPWD(oldpwd);
            if(model.PWD == oldpwd  || newpwd2 == newpwd)
            {
                model.PWD = newpwd2;
                _mgr.UpdatePwd(model);
                Response.Write("<script>alert('已變更成功!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('原密碼錯誤，請再確認一次!!')</script>");
            }

        }

        protected void btnNICKyes_Click(object sender, EventArgs e)
        {

        }
    }
}