namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAccounts
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserAccount { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPasswordSalt { get; set; }

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; }

        public int UserLevel { get; set; }

        public DateTime CreateDate { get; set; }

        public int UserPoints { get; set; }

        public int UserMoney { get; set; }
    }
}
