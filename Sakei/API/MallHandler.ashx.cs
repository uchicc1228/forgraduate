using Sakei.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.API
{
    /// <summary>
    /// MallHandler 的摘要描述
    /// </summary>
    public class MallHandler : IHttpHandler
    {
        private ShoppingListManager _shoppingMgr = new ShoppingListManager();
        public void ProcessRequest(HttpContext context)
        {
            //輸出單筆服裝資料
            if (string.Compare("POST", context.Request.HttpMethod, true) == 0 &&
                string.Compare("Mall", context.Request.QueryString["Action"], true) == 0)
            {
                Guid userID = Guid.Parse(context.Request.Form["userID"]);
                Guid shoppingID = Guid.Parse(context.Request.Form["shoppingID"]);
                var userShopping = this._shoppingMgr.GetShoppingList(userID, shoppingID);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(userShopping);

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