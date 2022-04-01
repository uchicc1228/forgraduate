using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models
{
    public class ShoppingListModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ItemID { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}