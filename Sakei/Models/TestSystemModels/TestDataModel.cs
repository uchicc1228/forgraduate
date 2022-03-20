using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.TestSystemModels
{
    public class TestDataModel
    {
        public Guid TestID { get; set; }
        public byte TestLevel { get; set; }
        public string TestContent { get; set; }
        public char TestAnswer { get; set; }
        public bool IsEnable { get; set; }
    }
}