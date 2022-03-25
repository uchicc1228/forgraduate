namespace Sakei.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingLists
    {
        [Key]
        public Guid ShoppingID { get; set; }

        public Guid UserID { get; set; }

        public Guid ItemID { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
