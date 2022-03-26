using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models.ExamSystemModels
{
    public class PointsModel
    {
        public Guid PointsID { get; set; }
        public Guid UserID { get; set; }
        public int Correct { get; set; }
        public DateTime CreateTime { get; set; }
    }
}