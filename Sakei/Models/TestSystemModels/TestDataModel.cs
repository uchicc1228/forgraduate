using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.TestSystemModels
{
    public class TestDataModel
    {
        public Guid TestID { get; set; }
        public int TestLevel { get; set; }
        public int TestTypeID { get; set; }
        public string TypeContext { get; set; }
        public string TestContent { get; set; }
        public string OptionsA { get; set; }
        public string OptionsB { get; set; }
        public string OptionsC { get; set; }
        public string OptionsD { get; set; }
        public string TestAnswer { get; set; }
        public bool IsEnable { get; set; }
    }
    
}