namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdminAccounts
    {
        [Key]
        public Guid AdminID { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminAccount { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPasswordSalt { get; set; }

        public int AdminLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }
    }
}
