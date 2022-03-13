using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaKei.Models
{
    public class AccountModel
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public UserLevelEnum UserLevel { get; set; }
    }
}