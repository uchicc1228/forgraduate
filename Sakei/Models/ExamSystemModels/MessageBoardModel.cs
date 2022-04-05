using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.ExamSystemModels
{
    public class MessageBoardModel
    {
        public Guid MessageID { get; set; }
        public Guid TestID { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }
        public string Character { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreateDate { get; set; }

    }
}