using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.TestSystemModels
{
    public class UserAnswerModel
    {
        public Guid UserID { get; set; }
        public Guid TestID { get; set; }
        public string UserAnswer { get; set; }
        public string UserNote { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary> 判斷是否已存在資料庫，不存入資料庫 </summary>
        public bool IsNew { get; set; }
    }
}