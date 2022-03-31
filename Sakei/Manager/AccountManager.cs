using Sakei.Helper;
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
        UserModel model = new UserModel();
        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage();

        public UserModel GetAccount(string account)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM UserAccounts
                    WHERE UserAccount = @account";
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
                            UserModel model = new UserModel()
                            {
                                Account = reader["UserAccount"] as string,
                                PWD = reader["UserPassword"] as string,
                                Mail = reader["UserEmail"] as string,
                                Salt_string = reader["UserPasswordSalt"] as string,
                                ID = (Guid)reader["UserID"],

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
        public UserModel GetAccount(Guid id)
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
                            UserModel model = new UserModel()
                            {
                                Account = reader["UserAccount"] as string,
                                PWD = reader["UserPassword"] as string,
                                Mail = reader["UserEmail"] as string,
                                Salt_string = reader["UserPasswordSalt"] as string,
                                ID = (Guid)reader["UserID"],

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

        /// <summary>
        /// 取得單筆使用者等級、等級積分、金錢
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserModel GetUserPointsAndMoney(Guid userID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM UserAccounts
                    WHERE UserID = @UserID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UserModel model = new UserModel()
                            {
                                UserLevel = (int)reader["UserLevel"],
                                UserPoints = (int)reader["UserPoints"],
                                UserMoney = (int)reader["UserMoney"]
                            };
                            return model;

                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("SaKei.Manager.AccountManager.GetUserLevel", ex);
                throw;
            }
        }
        public UserModel GetPWD(string PWD)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM UserAccounts
                    WHERE UserPassword = @pwd ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@pwd", PWD);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            UserModel model = new UserModel()
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

        public UserModel GetSaltString(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
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
                            UserModel model = new UserModel()
                            {
                                Salt_string = reader["UserPasswordSalt"] as string,                                
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

        public string GetCaptcha(string acc)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@" SELECT TOP(1) Gotcha.CAPTCHA
                   FROM UserAccounts
                   INNER JOIN Gotcha ON UserAccounts.UserID  =  Gotcha.UserID
                   WHERE UserAccount = @useracc
                   ORDER BY Gotcha.EmailDate DESC; ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        UserModel modelca = new UserModel();
                        command.Parameters.AddWithValue("@useracc", acc);
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            modelca.CAPTCHA = reader["CAPTCHA"] as string;


                        }

                        return modelca.CAPTCHA;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public int GetActiveorNot(string acc)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@" SELECT IsActivation
                    FROM [SakeTest].[dbo].[UserAccounts]
                    WHERE UserAccount = @useracc;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        UserModel modelca = new UserModel();
                        command.Parameters.AddWithValue("@useracc", acc);
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            modelca.IsActivition = (int)reader["IsActivation"];
                            

                        }

                        return modelca.IsActivition;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;

            }
        }

        public DateTime GetDate(string captcha)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT EmailDate
                    FROM Gotcha
                    WHERE CAPTCHA = @captcha ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@captcha", captcha);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UserModel model = new UserModel()
                            {
                                EmailDate = (DateTime)reader["EmailDate"] 
                               
                            };
                            return model.EmailDate;

                        }

                        return DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("", ex);
                throw;
            }
        }


        #region "忘記密碼 信箱"
        //回傳布林直
        public bool ForgotEmail(string account, string email)
        {
            bool isAccountRight = false;
            bool isEmailRight = false;

            UserModel member = this.GetAccount(account);

            if (member == null) // 找不到
                return false;

            if (string.Compare(member.Account, account, true) == 0)
                isAccountRight = true;

            if (member.Mail == email)
                isEmailRight = true;

            // 檢查帳號密碼是否正確
            bool result = (isAccountRight && isEmailRight);

            return result;
        }
        //寄出認證信 忘記密碼
        public UserModel SendEmail(Guid id, string mail)
        {

            string mail1 = "http://localhost:8974/MailAuthentication.aspx";
            em.From = new System.Net.Mail.MailAddress("sakei20220313@gmail.com", "鮭魚日文", System.Text.Encoding.UTF8);
            em.To.Add(new System.Net.Mail.MailAddress(mail));    //收件者
            em.Subject = "鮭魚日文 忘記密碼認證信";     //信件主題 
            em.SubjectEncoding = System.Text.Encoding.UTF8;
            em.Body = "<h1>請點擊下列網址以便找回密碼</h1><br/>鮭魚日文忘記密碼網址:" + mail1 + "?" + id;            //內容 
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
        public bool SendEmail(string email, int captcha)
        {

            try
            {
                em.From = new System.Net.Mail.MailAddress("sakei20220313@gmail.com", "鮭魚日文", System.Text.Encoding.UTF8);
                em.To.Add(new System.Net.Mail.MailAddress(email));    //收件者
                em.Subject = "鮭魚日文，註冊帳號驗證信";     //信件主題 
                em.SubjectEncoding = System.Text.Encoding.UTF8;
                em.Body = "您的驗證碼為: " + captcha +"<br/> 時效為10分鐘，超過請重新申請帳號。";            //內容 
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
            catch(Exception ex)
            {
                return false;
            }

          
        }

        #endregion

        #region "一般會員忘記密碼後更改自己密碼" 

        public void UpdatePwd(UserModel model)
        {
            model.Salt_string = Convert.ToBase64String(model.Salt);

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE UserAccounts
                    SET 
                        UserPassword = @pwd,
                        UserPasswordSalt = @salt

                    WHERE
                        UserID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@pwd", model.PWD);
                        command.Parameters.AddWithValue("@salt", model.Salt_string);
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

            UserModel member = this.GetAccount(account);

            if (member == null) // 找不到就代表登入失敗
                return false;

            if (string.Compare(member.Account, account, true) == 0)
                isAccountRight = true;

            if (member.PWD == password)
                isPasswordRight = true;

            // 檢查帳號密碼是否正確
            bool result = (isAccountRight && isPasswordRight);
            return result;
        }



        #endregion

        #region "註冊"

        public bool CreateAccounthash(UserModel model)
        {
            model.Salt_string = Convert.ToBase64String(model.Salt);

            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(model.Account) != null)

                throw new Exception("已存在相同的帳號");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" INSERT INTO UserAccounts
                        (UserAccount, UserPassword, UserEmail ,UserID, UserPasswordSalt)
                    VALUES
                        (@account, @pwd , @email, @id1, @salt);" +
                @"INSERT INTO[User]
                        (UserID)
                    VALUES
                        (@id)";



            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        //model.ID = Guid.NewGuid();
                        command.Parameters.AddWithValue("@account", model.Account);
                        command.Parameters.AddWithValue("@pwd", model.PWD);
                        command.Parameters.AddWithValue("@email", model.Mail);
                        command.Parameters.AddWithValue("@salt", model.Salt_string);
                        command.Parameters.AddWithValue("@id1", model.ID);
                        command.Parameters.AddWithValue("@id", model.ID);


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
        public bool CreateAccount(UserModel model)
        {
            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(model.Account) != null)

                throw new Exception("已存在相同的帳號");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" INSERT INTO UserAccounts
                        (UserAccount, UserPassword, UserEmail ,UserID)
                    VALUES
                        (@account, @pwd , @email, @id1);" +
                @"INSERT INTO[User]
                        (UserID)
                    VALUES
                        (@id)";



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

                        command.Parameters.AddWithValue("@id1", model.ID);
                        command.Parameters.AddWithValue("@id", model.ID);


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
        public bool CreateAdminAccounthash(UserModel model)
        {
            model.Salt_string = Convert.ToBase64String(model.Salt);

            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(model.Account) != null)

                throw new Exception("已存在相同的帳號");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" INSERT INTO UserAccounts
                        (UserAccount, UserPassword, UserEmail ,UserID, UserPasswordSalt)
                    VALUES
                        (@account, @pwd , @email, @id1, @salt);" +
                @"INSERT INTO[User]
                        (UserID)
                    VALUES
                        (@id)";



            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        //model.ID = Guid.NewGuid();
                        command.Parameters.AddWithValue("@account", model.Account);
                        command.Parameters.AddWithValue("@pwd", model.PWD);
                        command.Parameters.AddWithValue("@email", model.Mail);
                        command.Parameters.AddWithValue("@salt", model.Salt_string);
                        command.Parameters.AddWithValue("@id1", model.ID);
                        command.Parameters.AddWithValue("@id", model.ID);


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

        public bool CreatCapcha(UserModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" INSERT INTO Gotcha
                        (UserID, EmailDate, CAPTCHA)
                    VALUES
                        (@UserID, @EmailDate , @CAPTCHA);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@UserID", model.ID);
                        command.Parameters.AddWithValue("@EmailDate", model.EmailDate);
                        command.Parameters.AddWithValue("@CAPTCHA", model.CAPTCHA);

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

        public bool ActiveCapcha(string acc)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE UserAccounts
                    SET 
                        IsActivation = 1  
                    WHERE
                        UserAccounts.UserAccount = @acc";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@acc", acc);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog("UpdatePwd", ex);
                return false;
            }

        }




        #endregion

        #region "主頁面找暱稱"

        //暫時用不到
        public UserModel GetNickName(string acc)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [User]
                    WHERE UserAccount = @account ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@account", acc);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            UserModel model = new UserModel()
                            {
                                Account = reader["UserAccount"] as string,
                                UserName = reader["UserName"] as string,
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


        public UserModel GetNickName(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [User]
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
                            UserModel model = new UserModel()
                            {

                                UserName = reader["UserName"] as string,
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

        //驗證密碼格式
        public bool isValidPWD(string inputPWD)
        {
            string strRegex = @"(?=^.{8,20}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputPWD))
                return (true);
            else
                return (false);
        }
        #endregion

        #region "用帳號刪除"
        public void DeleteAcc(string acc)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@"  Delete from UserAccounts
                     where UserAccount = @useracc; ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        UserModel modelca = new UserModel();
                        command.Parameters.AddWithValue("@useracc", acc);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            modelca.Account = reader["UserAccount"] as string;

                        }


                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }



}