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

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //帳號
            model.Account = this.txtAcc.Text.Trim();
            if (model.Account.Length < 8 || model.Account.Length > 20)
            {
                Response.Write("<script>alert('請注意帳號長度，須為８～２０字元')</script>");
                return;
            }

            //密碼
            model.PWD = this.txtPWD.Text.Trim();
            if (model.PWD.Length < 8 || model.PWD.Length > 20)
            {
                Response.Write("<script>alert('請注意密碼長度，須為８～２０字元')</script>");
                return;
            }


            //信箱
            model.Mail = this.txtMail.Text.Trim();
            if (!_mgr.isValidEmail(model.Mail))
            {
                Response.Write("<script>alert('請注意信箱格式')</script>");
                return;
            }

            //判斷帳號是否存在
            if (_mgr.GetAccount(model.Account) != null)
            {
                Response.Write("<script>alert('存在相同帳號!')</script>");
                return;
            }

            //修正此處 產生一組變數 帶到信封內 
            Random rnd = new Random();
            int captcha = Convert.ToInt32(rnd.Next(1, 99999));

            if (_mgr.SendEmail(model.Mail, captcha))
            {
                Response.Write("<script>alert('已發送驗證信!!')</script>");
                this.txtcaptcha.Visible = true;
            }

            HttpCookie cookies = new HttpCookie("captcha");
            cookies.Name = "captcha"; //只能放英文跟數字 
            cookies.Value = captcha.ToString();
            cookies.HttpOnly = true;  //只允許server端的程式碼做要求cookies的存取 不允許第三方程式
            cookies.Secure = true;  //只允許https 使用存取cookies (機密性資料
            Response.Cookies.Add(cookies);



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {


            HttpCookie cookies = Request.Cookies["captcha"]; //找到的cookies是Name來找 

            if (this.txtcaptcha.Text.Trim() == cookies.ToString())
            {
                _mgr.CreateAccount(model);
                Response.Write("<script>alert('註冊成功!!')</script>");

            }

        }

    }
}