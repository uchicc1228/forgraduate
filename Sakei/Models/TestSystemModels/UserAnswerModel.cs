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
        public char UserAnswer { get; set; }
        public string UserNote { get; set; }
        public DateTime CreateDate { get; set; }
    }
}