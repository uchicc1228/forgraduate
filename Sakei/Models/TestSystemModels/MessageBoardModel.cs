using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.TestSystemModels
{
    public class MessageBoardModel
    {
        public Guid MessageID { get; set; }
        public Guid TestID { get; set; }
        public Guid UserID { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreateDate { get; set; }

    }
}