using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models
{
    public class TestModel
    {
        public Guid ID { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }
        
        public string Content { get; set; }
        public string OptionsA { get; set; }
        public string OptionsB { get; set; }
        public string OptionsC { get; set; }
        public string OptionsD { get; set; }
        public string Answer { get; set; }
        public DateTime CreatTime { get; set; }
        public int IsEnable { get; set; }


    }
}