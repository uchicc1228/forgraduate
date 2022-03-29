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

        public void ProcessRequest(HttpContext context)
        {
            if (string.Compare("GET", context.Request.HttpMethod, true) == 0)
            {
                var aa = "aa";
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(aa);

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