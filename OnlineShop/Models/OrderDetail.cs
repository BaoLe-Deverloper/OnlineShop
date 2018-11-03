namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int DetailID { get; set; }

        public int? DetialOrderID { get; set; }

        [StringLength(10)]
        public string DetialProductName { get; set; }

        public int? DetialProductID { get; set; }

        [StringLength(10)]
        public string DetialProductPrice { get; set; }

        public int? DetialQuantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
