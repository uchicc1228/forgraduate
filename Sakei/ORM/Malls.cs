namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Malls
    {
        [Key]
        public Guid ItemID { get; set; }

        public int ItemLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        [Required]
        public string ItemContent { get; set; }

        public int ItemPrice { get; set; }

        public bool IsEnable { get; set; }
    }
}
