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
        public string PWD { get; set; }
        public UserLevelEnum UserLevel { get; set; }

        public string Mail { get; set; }    

        public string sex { get; set; }
    }
}