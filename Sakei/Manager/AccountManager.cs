﻿using Sakei.Helper;
using SaKei.Helpers;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SaKei.Manager
{
    public class AccountManager
    {
        AccountModel model = new AccountModel();
        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage();
        LoginHelper _log = new LoginHelper();
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
                    FROM UserAccounts
                    WHERE UserAccount = @account ";
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
                                Account = reader["UserAccount"] as string,
                                PWD = reader["UserPassword"] as string,
                                Mail = reader["UserEmail"] as string,
                                ID = (Guid)reader["UserID"]
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
                    FROM UserAccounts
                    WHERE UserID = @id ";
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
                            AccountModel model = new AccountModel()
                            {
                                ID = (Guid)reader["UserID"],
                                Account = reader["UseAccount"] as string,
                                PWD = reader["UsePassword"] as string,

                            };
                            return model;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("GetAccount", ex);
                throw;
            }
        }

        public AccountModel GetCurrentUser()
        {
            AccountModel account = HttpContext.Current.Session["MemberAccount"] as AccountModel;
            return account;
        }

        #region "忘記密碼 信箱"
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
        public AccountModel SendEmail(Guid id)
        {

            string mail1 = "http://localhost:8974/MailAuthentication.aspx";
            em.From = new System.Net.Mail.MailAddress("sakei20220313@gmail.com", "鮭魚日文", System.Text.Encoding.UTF8);
            em.To.Add(new System.Net.Mail.MailAddress("doudada0807@gmail.com"));    //收件者
            em.Subject = "123";     //信件主題 
            em.SubjectEncoding = System.Text.Encoding.UTF8;
            em.Body = mail1 + "?" + id;            //內容 
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

            return model;

        }
        public bool SendEmail(string email , int captcha)
        {
           
            
            em.From = new System.Net.Mail.MailAddress("sakei20220313@gmail.com", "鮭魚日文", System.Text.Encoding.UTF8);
            em.To.Add(new System.Net.Mail.MailAddress(email));    //收件者
            em.Subject = "鮭魚日文，註冊帳號驗證信";     //信件主題 
            em.SubjectEncoding = System.Text.Encoding.UTF8;
            em.Body = "您的驗證碼為: " + captcha;            //內容 
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

            return true;

        }

        #endregion

        #region "一般會員忘記密碼後更改自己密碼" 

        public void UpdatePwd(AccountModel 媽的幹)
        {
            // 1. 編輯資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE UserAccounts
                    SET 
                        UserPassword = @pwd
                    WHERE
                        UserID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", 媽的幹.ID);
                        command.Parameters.AddWithValue("@pwd", 媽的幹.PWD);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("UpdatePwd", ex);
                throw;
            }
        }





        #endregion

        #region "登入"

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

            ///帳密正確：把值寫入 cookies
            //
            //if (result)
            //{

            //    member.PWD = null;
            //    HttpContext.Current.Session["MemberAccount"] = member;
            //}
            return result;
        }



        #endregion

        #region "註冊"
        public bool CreateAccount(AccountModel model)
        {
            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(model.Account) != null)

                throw new Exception("已存在相同的帳號");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  INSERT INTO UserAccounts
                        (UserAccount, UserPassword, UserEmail)
                    VALUES
                        (@account, @pwd , @email)";


            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        model.ID = Guid.NewGuid();

                       
                        command.Parameters.AddWithValue("@account", model.Account);
                        command.Parameters.AddWithValue("@pwd", model.PWD);
                        command.Parameters.AddWithValue("@email", model.Mail);



                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            
            return true;
            }
            catch (Exception ex)
            {
                
                Logger.WriteLog("CreateAccount", ex);
                return false;
            }
        }
        #endregion

        #region "各式防呆和驗證"

        //驗證信箱格式
        public bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        #endregion




    }



}