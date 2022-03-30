using Sakei.Manager.ExamSystemManagers;
using Sakei.Models.ExamSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.API
{
    /// <summary>
    /// 用作考題回顧的留言板與筆記資料變換
    /// </summary>
    public class ExamReviewHandler : IHttpHandler
    {
        private UserAnswerManager _userAnsMgr = new UserAnswerManager();
        private MessageBoardManager _msgBoardMgr = new MessageBoardManager();
        public void ProcessRequest(HttpContext context)
        {
            
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0)
            {
                Guid userID = Guid.Parse(context.Request.Form["userID"]);
                Guid testID = Guid.Parse(context.Request.Form["testID"]);
                var userAnswer = this._userAnsMgr.GetUserAnswer(userID, testID);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(userAnswer);

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