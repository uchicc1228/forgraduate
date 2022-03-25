namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PointsLists
    {
        [Key]
        public Guid PointsID { get; set; }

        public Guid UserID { get; set; }

        [Required]
        [StringLength(10)]
        public string Correct { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
