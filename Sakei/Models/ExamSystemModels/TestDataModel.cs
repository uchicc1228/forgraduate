using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.ExamSystemModels
{
    public class TestDataModel
    {
        public Guid TestID { get; set; }
        public int TestLevel { get; set; }
        public int TestTypeID { get; set; }
        public string TypeContext { get; set; }
        public string TestContent { get; set; }
        /// <summary>
        /// 題目簡介
        /// </summary>
        public string TestContentShort { get => TestContent.Substring(0, 10); }
        public string OptionsA { get; set; }
        public string OptionsB { get; set; }
        public string OptionsC { get; set; }
        public string OptionsD { get; set; }
        public string TestAnswer { get; set; }
        public bool IsEnable { get; set; }
    }

}