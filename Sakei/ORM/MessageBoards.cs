namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MessageBoards
    {
        [Key]
        public Guid MessageID { get; set; }

        public Guid TestID { get; set; }

        public Guid UserID { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
