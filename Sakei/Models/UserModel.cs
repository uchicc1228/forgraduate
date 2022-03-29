using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaKei.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string PWD { get; set; }
        public int UserLevel { get; set; }
        public string Mail { get; set; }            
        public string Salt_string { get; set; }
        public byte[] Salt { get; set; }

        public int IsActivition { get; set; }
        public DateTime EmailDate { get; set; }
        public string CAPTCHA { get; set; }  
        public string UserName { get; set; }
        /// <summary>
        /// 使用者等級積分
        /// </summary>
        public int UserPoints { get; set; }
        public int UserMoney { get; set; }

        public string Character { get; set; }
    }
}