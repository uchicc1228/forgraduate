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
        private PointsManager _poinMgr = new PointsManager();
        public void ProcessRequest(HttpContext context)
        {
            //查詢考題資料
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("Start", context.Request.QueryString["Exam"], true) == 0)
            {
                int testLv = int.Parse(context.Request.Form["TestLevel"]);
                int testCount = int.Parse(context.Request.Form["TestCount"]);
                Guid userID = Guid.Parse(context.Request.Form["UserID"]);
                bool isChalleng = bool.Parse(context.Request.Form["IsChalleng"]);
                var examDataList = this._examMgr.GetTestDataForTest(testLv, testCount, userID, isChalleng);
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
            //結算，寫入點數、金幣、等級，增加考試的紀錄
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("Settlement", context.Request.QueryString["Exam"], true) == 0)
            {
                Guid userID = Guid.Parse(context.Request.Form["UserID"]);
                int correct = int.Parse(context.Request.Form["Correct"]);
                int userLevel = int.Parse(context.Request.Form["UserLevel"]);
                int Point = int.Parse(context.Request.Form["Point"]);
                //使用者現在持有的積分
                int UserPoints = int.Parse(context.Request.Form["UserPoints"]);
                int Money = int.Parse(context.Request.Form["Money"]);
                //判斷是否達等級提升標準、是否成功升級
                if (userLevel > 1 && UserPoints >= 90 && Point > 10)
                {
                    userLevel -= 1;
                    UserPoints = 0;
                }
                else if (UserPoints + Point < 0)
                {
                    UserPoints = 0;
                }
                else
                {
                    UserPoints += Point;
                }

                _poinMgr.CreatePoints(userID, correct, userLevel, UserPoints, Money);
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