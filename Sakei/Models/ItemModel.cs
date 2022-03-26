using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models
{
    public class ItemModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public int IsEnable { get; set; }
    }
}