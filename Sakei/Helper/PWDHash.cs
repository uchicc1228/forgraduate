using SaKei.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Sakei.Helper
{

    public class PWDHash
    {
       
        //登入用hash
        public static string LoginHash(string pwd, AccountModel model)
        {

         
            string orgText = pwd;
            string key = Convert.ToString(model.ID);
            byte[] salt = Convert.FromBase64String(model.Salt_string);
            byte[] securityBytes = GetHashPassword(orgText, key, salt);
            model.PWD =
                string.Join(
                    "", securityBytes.Select(obj => obj.ToString("x"))
                    );
            
            return model.PWD;
        }
        public static string LoginHashAdmin(string pwd, AdminAccountModel model)
        {


            string orgText = pwd;
            string key = Convert.ToString(model.ID);
            byte[] salt = Convert.FromBase64String(model.Salt_string);
            byte[] securityBytes = GetHashPassword(orgText, key, salt);
            model.PWD =
                string.Join(
                    "", securityBytes.Select(obj => obj.ToString("x"))
                    );

            return model.PWD;
        }


        #region "註冊的雜湊"
        public static AccountModel Hash(AccountModel model)
        {
            model.ID = Guid.NewGuid();
            string orgText = model.PWD;
            string key = Convert.ToString(model.ID);
            byte[] salt = BuildNewSalt();
            
            byte[] securityBytes = GetHashPassword(orgText, key, salt);
            model.PWD =
                string.Join(
                    "", securityBytes.Select(obj => obj.ToString("x"))
                    );
            model.Salt = salt;
            return model;
        }

        #endregion

        #region "新增管理者的雜湊"
        public static AdminAccountModel AdminHash(AdminAccountModel model)
        {
            model.ID = Guid.NewGuid();
            string orgText = model.PWD;
            string key = Convert.ToString(model.ID);
            byte[] salt = BuildNewSalt();

            byte[] securityBytes = GetHashPassword(orgText, key, salt);
            model.PWD =
                string.Join(
                    "", securityBytes.Select(obj => obj.ToString("x"))
                    );
            model.Salt = salt;
            return model;
        }

        #endregion
        public static byte[] BuildNewSalt()
        {
            byte[] randBytes = new byte[32];
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            rand.GetBytes(randBytes);
            return randBytes;
        }

        /// <summary> 密碼進行雜湊 </summary>
        /// <param name="key">金鑰</param>
        /// <param name="pwd">密碼</param>
        /// <param name="salt">鹽</param>
        /// <returns></returns>
        public static byte[] GetHashPassword(string key, string pwd, byte[] salt)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] pwdBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] totalBytes = salt.Union(pwdBytes).ToArray();




            HMACSHA512 hmacsha512 = new HMACSHA512(keyByte);
            byte[] hashPwd = hmacsha512.ComputeHash(totalBytes);
            return hashPwd;
        }

       
    }

}