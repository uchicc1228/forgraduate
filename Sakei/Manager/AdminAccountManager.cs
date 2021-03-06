using Sakei.Helper;
using Sakei.Models;
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
    public class AdminAccountManager
    {
        AdminAccountModel model = new AdminAccountModel();
        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage();
        LoginHelper _log = new LoginHelper();


        private AdminAccountModel BuildAccountModel(SqlDataReader reader)
        {
            AdminAccountModel model = new AdminAccountModel()
            {
                ID = (Guid)reader["ID"],
                Account = reader["Account"] as string,
                PWD = reader["PWD"] as string,
                Level = (int)reader["Level"]
            };
            return model;
        }
        public bool IsLogined()
        {
            AdminAccountModel account = GetCurrentUser();
            return (account != null);
        }
        public AdminAccountModel GetAccount(string account)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM AdminAccounts
                    WHERE AdminAccount = @account";
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
                            AdminAccountModel model = new AdminAccountModel()
                            {
                                Account = reader["AdminAccount"] as string,
                                PWD = reader["AdminPassword"] as string,
                                Mail = reader["AdminEmail"] as string,
                                Salt_string = reader["AdminPasswordSalt"] as string,
                                ID = (Guid)reader["AdminID"],
                                IsEnableBool = (bool)reader["IsEnable"]
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
        //透過id取得帳號資訊
        public AdminAccountModel GetAccount(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM AdminAccounts
                    WHERE AdminID = @id ";
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
                            AdminAccountModel model = new AdminAccountModel()
                            {
                                ID = (Guid)reader["AdminID"],
                                Account = reader["AdminAccount"] as string,
                                PWD = reader["AdminPassword"] as string,

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
        //取得密碼
        public AdminAccountModel GetPWD(string PWD)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM AdminAccounts
                    WHERE AdminPassword = @pwd ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@pwd", PWD);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            AdminAccountModel model = new AdminAccountModel()
                            {
                                Account = reader["AdminAccount"] as string,
                                PWD = reader["AdminPassword"] as string,
                                Mail = reader["AdminEmail"] as string,
                                ID = (Guid)reader["AdminID"]
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
        public AdminAccountModel GetCurrentUser()
        {
            AdminAccountModel account = HttpContext.Current.Session["MemberAccount"] as AdminAccountModel;
            return account;
        }


        #region "忘記密碼 信箱"
        //回傳布林直
        public bool ForgotEmail(string account, string email)
        {
            bool isAccountRight = false;
            bool isEmailRight = false;

            AdminAccountModel member = this.GetAccount(account);

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
        public AdminAccountModel SendEmail(Guid id, string mail)
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

        public void UpdatePwd(AdminAccountModel model)
        {
            // 1. 編輯資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE AdminAccounts
                    SET 
                        AdminPassword = @pwd
                    WHERE
                        AdminID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@pwd", model.PWD);

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

            AdminAccountModel member = this.GetAccount(account);

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

        public bool CreateAdminAccounthash(AdminAccountModel model)
        {
            model.Salt_string = Convert.ToBase64String(model.Salt);

            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetAccount(model.Account) != null)

                throw new Exception("已存在相同的帳號");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" INSERT INTO AdminAccounts
                        (AdminID,AdminName, AdminAccount, AdminPassword, AdminPasswordSalt, AdminEmail , AdminLevel,IsEnable)
                    VALUES
                        (@id,  @name, @account, @pwd , @salt, @email, @level,@isenable );";



            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@name", model.Name);
                        command.Parameters.AddWithValue("@account", model.Account);
                        command.Parameters.AddWithValue("@pwd", model.PWD);
                        command.Parameters.AddWithValue("@salt", model.Salt_string);
                        command.Parameters.AddWithValue("@email", model.Mail);
                        command.Parameters.AddWithValue("@level", model.Level);
                        command.Parameters.AddWithValue("@isenable", model.IsEnable);
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
        //檢驗帳號密碼
        public bool GetActiveorNot(string acc)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@" SELECT IsEnable
                    FROM [SakeTest].[dbo].[AdminAccounts]
                    WHERE AdminAccount = @adminacc;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        AdminAccountModel modelca = new AdminAccountModel();
                        command.Parameters.AddWithValue("@adminacc", acc);
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            modelca.IsEnableBool = (bool)reader["IsEnable"];
                           
                        }

                        return modelca.IsEnableBool;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;

            }
        }



    }



}