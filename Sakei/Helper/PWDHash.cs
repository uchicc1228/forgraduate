﻿using SaKei.Models;
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
        AccountModel model =  new AccountModel();
      
        public static AccountModel  Hash(AccountModel model)
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
            model.salt = Convert.ToString(securityBytes);
            return model;
        }


        public static byte[] BuildNewSalt()
        {
            byte[] randBytes = new byte[8];
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