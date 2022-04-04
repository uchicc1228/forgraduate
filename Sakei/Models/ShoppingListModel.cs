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
        public int ItemLevel { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary> 判斷是否已存在資料庫，不存入資料庫 </summary>
        public bool IsHave { get; set; }
    }
}