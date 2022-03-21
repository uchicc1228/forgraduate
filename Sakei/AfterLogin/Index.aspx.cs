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
             string acc = Request.QueryString["Q1"];
             Guid guid = Guid.Parse(acc);  
            AccountModel model = _mgr.GetNickName(guid);


            //將query解密
            //string acc = System.Text.Encoding.Default.GetString(Convert.FromBase64String(Request.QueryString["Q1"].ToString().Replace("+", "% 2B")));
            //AccountModel model = _mgr.GetNickName(acc);


            string nickname = model.NickName;
            this.lblName.Text =  nickname;

        }

        protected void btnInfoCh_Click(object sender, EventArgs e)
        {
            this.plcPWDChanger.Visible = true;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {

        }
    }
}