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
            //輸出單筆筆記資料
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("Note", context.Request.QueryString["Action"], true) == 0)
            {
                Guid userID = Guid.Parse(context.Request.Form["userID"]);
                Guid testID = Guid.Parse(context.Request.Form["testID"]);
                var userAnswer = this._userAnsMgr.GetUserAnswer(userID, testID);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(userAnswer);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
                return;
            }
            //輸出單題留言版資料
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("MsgBoard", context.Request.QueryString["Action"], true) == 0)
            {
                Guid testID = Guid.Parse(context.Request.Form["testID"]);
                var msgBoardList = this._msgBoardMgr.GetMessageBoardList(testID);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(msgBoardList);

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