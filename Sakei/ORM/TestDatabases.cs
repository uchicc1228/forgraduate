namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestDatabases
    {
        [Key]
        public Guid TestID { get; set; }

        public int TestLevel { get; set; }

        public int TestTypeID { get; set; }

        [Required]
        public string TestContent { get; set; }

        [Required]
        [StringLength(200)]
        public string OptionsA { get; set; }

        [Required]
        [StringLength(200)]
        public string OptionsB { get; set; }

        [Required]
        [StringLength(200)]
        public string OptionsC { get; set; }

        [Required]
        [StringLength(200)]
        public string OptionsD { get; set; }

        public DateTime CreatTime { get; set; }

        [Required]
        [StringLength(10)]
        public string TestAnswer { get; set; }

        public bool IsEnable { get; set; }
    }
}
