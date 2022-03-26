using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public Guid ItemID { get; set; }
        public string UserName { get; set; }
        public string Character { get; set; }
    }
}