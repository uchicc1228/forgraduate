namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAnswers
    {
        [Key]
        public Guid UserID { get; set; }

        public Guid TestID { get; set; }

        [Required]
        [StringLength(10)]
        public string UserAnswer { get; set; }

        public string UserNote { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
