using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SaKei.Models
{
    public class AdminAccountModel
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string PWD { get; set; }
        public byte[] Salt { get; set; }
        public string Salt_string { get; set; }
        public string Mail { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }


    }
}