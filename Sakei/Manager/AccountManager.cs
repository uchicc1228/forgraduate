using DeliciousMap.Helpers;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace SaKei.Manager
{
    public class AccountManager
    {
        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage();
        private AccountModel BuildAccountModel(SqlDataReader reader)
        {
            AccountModel model = new AccountModel()
            {
                ID = (Guid)reader["ID"],
                Account = reader["Account"] as string,
                PWD = reader["PWD"] as string,
                UserLevel = (UserLevelEnum)reader["UserLevel"]
            };
            return model;
        }
        public bool TryLogin(string account, string password)
        {
            bool isAccountRight = false;
            bool isPasswordRight = false;

            AccountModel member = this.GetAccount(account);

            if (member == null) // 找不到就代表登入失敗
                return false;

            if (string.Compare(member.Account, account, true) == 0)
                isAccountRight = true;

            if (member.PWD == password)
                isPasswordRight = true;

            // 檢查帳號密碼是否正確
            bool result = (isAccountRight && isPasswordRight);

            // 帳密正確：把值寫入 Session
            // 為避免任何漏洞導致 session 流出，先把密碼清除
            if (result)
            {
                member.PWD = null;
                HttpContext.Current.Session["MemberAccount"] = member;
            }

            return result;
        }

        #region "忘記密碼"
        //回傳布林直
        public bool ForgotEmail(string account, string email)
        {
            bool isAccountRight = false;
            bool isEmailRight = false;

            AccountModel member = this.GetAccount(account);

            if (member == null) // 找不到
                return false;

            if (string.Compare(member.Account, account, true) == 0)
                isAccountRight = true;

            if (member.Mail == email)
                isEmailRight = true;

            // 檢查帳號密碼是否正確
            bool result = (isAccountRight && isEmailRight);

            //// 信箱和帳號正確：把值寫入 Session
            //if (result)
            //{
            //    HttpContext.Current.Session["MemberEmail"] = member;
            //    HttpContext.Current.Session["MemberAccount"] = member;
            //}

            return result;
        }
        //寄出認證信
        public void SendEmail()
        {
            em.From = new System.Net.Mail.MailAddress("sakei20220313@gmail.com", "鮭魚日文", System.Text.Encoding.UTF8);
            em.To.Add(new System.Net.Mail.MailAddress("doudada0807@gmail.com"));    //收件者
            em.Subject = "123";     //信件主題 
            em.SubjectEncoding = System.Text.Encoding.UTF8;
            em.Body = "123";            //內容 
            em.BodyEncoding = System.Text.Encoding.UTF8;
            em.IsBodyHtml = true;     //信件內容是否使用HTML格式



            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            //登入帳號認證  
            smtp.Credentials = new System.Net.NetworkCredential("sakei20220313@gmail.com", "lhuohuxmqnepcvic");
            //使用587 Port - google要設定
            smtp.Port = 587;
            smtp.EnableSsl = true;   //啟動SSL 
            //end of google設定
            smtp.Host = "smtp.gmail.com";   //SMTP伺服器
            smtp.Send(em);            //寄出



        }

        #endregion

        public bool IsLogined()
        {
            AccountModel account = GetCurrentUser();
            return (account != null);
        }

        public AccountModel GetAccount(string account)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM Sakeiusers
                    WHERE Account = @account ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@account", account);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            AccountModel model = new AccountModel()
                            {
                                Account = reader["Account"] as string,
                                Mail = reader["Mail"] as string
                            };
                            return model;
                           
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("", ex);
                throw;
            }
        }
        public AccountModel GetAccount(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Accounts
                    WHERE ID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            AccountModel member = BuildAccountModel(reader);
                            return member;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }
        public AccountModel GetCurrentUser()
        {
            AccountModel account = HttpContext.Current.Session["MemberAccount"] as AccountModel;
            return account;
        }
        //protected void Send_mail(string authcode, string email)
        //{
        //    string msgstr = "";
        //    msgstr = "your msg";

        //    //Send Mail
        //    MailMessage NewMail = new MailMessage("來源端的mail address", " 目的端的mail address", "mail title ", msgstr);
        //    NewMail.BodyEncoding = System.Text.Encoding.GetEncoding("big5");
        //    NewMail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SmtpHost"].ToString());
        //    smtp.Send(NewMail);
        //}
    }



}