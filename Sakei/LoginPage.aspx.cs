﻿using Sakei.Helper;
using SaKei.Manager;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaKei
{
    //寫Login 配合今天上課的glbol 在golbol上面做驗證登入
    public partial class LoginPage : System.Web.UI.Page
    {


        private AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["prevUrl"] = Request.UrlReferrer.ToString();
                string urll = ViewState["prevUrl"].ToString();
                if (urll.Contains("/AfterLogin"))
                {

                    LoginHelper.Logout();
                   
                }
            }
            else
            {
                return;
            }

            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();

            //雜湊 卡在這 找不到salt 原因可能是型別問題

            AccountModel acc = _mgr.GetAccount(account);
            if (acc == null)
            {


            }
            else
            {
                pwd = PWDHash.LoginHash(pwd, acc);
            }



            if (this._mgr.TryLogin(account, pwd))
            {


                //票券cookies維持登入狀態 
                //todo: 一個登出紐 寫在usercontrol
                AccountModel acc1 = _mgr.GetAccount(account);
                LoginHelper.Login(acc1.Account, Convert.ToString(acc1.ID));
                Response.Redirect("AfterLogin\\Index.aspx");




                //將query加密 可能用不著
                //AccountModel q1 = _mgr.GetAccount(account);
                //Response.Redirect("AfterLogin/Index.aspx?Q1=" + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(q1.Account)).Replace("+", "% 2B"));
            }
            else
            {
                //this.ltlMessage.Text = "登入失敗，請檢查帳號密碼。";
                Response.Write("<script>alert('登入失敗，請檢查帳號密碼')</script>");
            }
        }
        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    LoginHelper.Logout();
        //    Response.Redirect(Request.RawUrl);
        //}

        protected void forgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPage.aspx");
        }


    }
}