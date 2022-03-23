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
        public static string LoginHash(string pwd, Guid ID, string salt)
        {
           
            string orgText = pwd;
            string key = Convert.ToString(ID);
            byte[] salt1 = Convert.FromBase64String(salt);
           

            byte[] securityBytes = GetHashPassword(orgText, key, salt1);
            pwd =
                string.Join(
                    "", salt1.Select(obj => obj.ToString("x"))
                    );

            return pwd;
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
            model.Salt = securityBytes;
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