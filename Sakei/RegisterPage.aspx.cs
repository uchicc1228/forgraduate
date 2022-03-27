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
    public partial class RegisterPage : System.Web.UI.Page
    {
        AccountModel model = new AccountModel();
        AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                this.ltlmsg.Text = "<b>密碼設定原則，須包含以下四點<br/>" + "1.含英文大寫及小寫字元<br/>" + "2.含至少一位數字<br/>" + "3.長度至少八碼，最長20碼 <br/>" + "4.可含特殊字元(#?!@$%^&*-) <br/>";
                this.plc1.Visible = false;
                this.plc2.Visible = true;
            }


            if (!Page.IsPostBack)
            {
                if (plc1.Visible == false)
                {
                    this.plc1.Visible = true;
                    this.plc2.Visible = false;

                }
            }

          

        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            model.Account = this.txtAcc.Text.Trim();
            if (model.Account.Length < 8 || model.Account.Length > 20)
            {
                Response.Write("<script>alert('請注意帳號長度，須為８～２０字元')</script>");
                return;
            }

            if (_mgr.GetAccount(model.Account) != null)
            {
                Response.Write("<script>alert('存在相同帳號!')</script>");
                return;
            }
            model.PWD = this.txtPWD.Text.Trim();

            if (!_mgr.isValidPWD(model.PWD))
            {
                Response.Write("<script>alert('請注意密碼格式')</script>");
                return;
            }
            model.Mail = this.txtMail.Text.Trim();

            if (!_mgr.isValidEmail(model.Mail))
            {
                Response.Write("<script>alert('請注意信箱格式')</script>");
                return;
            }

            //產生一組變數 帶到信封內  順便先註冊帳號 但尚未激活
            Random rnd = new Random();
            int _captcha = Convert.ToInt32(rnd.Next(10000, 99999));


            if (_mgr.SendEmail(model.Mail, _captcha))
            {
                Response.Write("<script>alert('已發送驗證信!!')</script>");
                this.plc1.Visible = true;
                this.plc2.Visible = false;
                string captcha = Convert.ToString(_captcha);
                model.CAPTCHA = captcha;
                model.ID = Guid.NewGuid();
                model.EmailDate = DateTime.Now;
                if (_mgr.CreatCapcha(model))
                {
                    model = PWDHash.Hash(model);
                    _mgr.CreateAccounthash(model);
                   
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
    
           
            if (this.txtcaptcha.Text.Trim() == _mgr.GetCaptcha(model.ID))
            {
                Response.Write("weee");
                //model = PWDHash.Hash(model);
                //_mgr.CreateAccounthash(model);
                //Response.Write("<script>alert('註冊成功!!')</script>");


            }
            else
            {
                Response.Write("<script>alert('錯誤的驗證碼!!')</script>");
            }




        }

    }
}