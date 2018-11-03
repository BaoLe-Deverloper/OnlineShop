namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderID { get; set; }

        [StringLength(100)]
        public string OrderUserName { get; set; }

        public int? OrderUserID { get; set; }

        public double? OrderAmount { get; set; }

        [StringLength(200)]
        public string OrderAddress1 { get; set; }

        [StringLength(200)]
        public string OrderAddress2 { get; set; }

        [StringLength(20)]
        public string OrderZip { get; set; }

        public int? OrderPhone { get; set; }

        public double? OrderTax { get; set; }

        public double? OrderSale { get; set; }

        [StringLength(20)]
        public string OrderEmail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [StringLength(100)]
        public string OrderTrackingNumber { get; set; }

        public byte? OrderStatus { get; set; }

        public int? IDNhanVien { get; set; }

        [StringLength(200)]
        public string OrderNote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual UserAdmin UserAdmin { get; set; }

        public virtual User User { get; set; }
    }
}
