using Sakei.Manager.ExamSystemManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.API
{
    /// <summary>
    /// ExamSystemHandler 的摘要描述
    /// </summary>
    public class ExamSystemHandler : IHttpHandler
    {
        private ExamDataManager _mgr = new ExamDataManager();
        public void ProcessRequest(HttpContext context)
        {
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("Start", context.Request.QueryString["Exam"], true) == 0)
            {
                int testLv = int.Parse(context.Request.Form["TestLevel"]);
                int testCount = int.Parse(context.Request.Form["TestCount"]);
                var examDataList = this._mgr.GetTestDataForTest(testLv, testCount);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(examDataList);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}