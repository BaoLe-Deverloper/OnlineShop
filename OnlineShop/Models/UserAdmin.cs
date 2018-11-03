namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAdmin")]
    public partial class UserAdmin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAdmin()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int UserID { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string UserPass { get; set; }

        public int? UserIDQuyen { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime? UserDateCreate { get; set; }

        public bool UserActive { get; set; }

        public double UserLuong { get; set; }

        [Column(TypeName = "xml")]
        public string UserImage { get; set; }

        [StringLength(100)]
        public string UserAddress { get; set; }

        [StringLength(20)]
        public string UserPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
