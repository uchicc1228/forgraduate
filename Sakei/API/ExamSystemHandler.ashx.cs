using Sakei.Manager.ExamSystemManagers;
using Sakei.Models.ExamSystemModels;
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
        private ExamDataManager _examMgr = new ExamDataManager();
        private UserAnswerManager _ansMgr = new UserAnswerManager();
        public void ProcessRequest(HttpContext context)
        {
            //查詢考題資料
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("Start", context.Request.QueryString["Exam"], true) == 0)
            {
                int testLv = int.Parse(context.Request.Form["TestLevel"]);
                int testCount = int.Parse(context.Request.Form["TestCount"]);
                Guid userID = Guid.Parse(context.Request.Form["UserID"]);
                var examDataList = this._examMgr.GetTestDataForTest(testLv, testCount,userID);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(examDataList);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
                return;
            }
            //寫入使用者答案
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("SaveAnswer", context.Request.QueryString["Exam"], true) == 0)
            {
                UserAnswerModel model = new UserAnswerModel()
                {
                    UserID = Guid.Parse(context.Request.Form["UserID"]),
                    TestID = Guid.Parse(context.Request.Form["TestID"]),
                    UserAnswer = context.Request.Form["UserAnswer"],
                    IsNew = bool.Parse(context.Request.Form["IsNew"])
                };
                this._ansMgr.SaveUserAnswer(model);

                context.Response.ContentType = "text/plain";
                context.Response.Write("OK");
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