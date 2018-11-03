namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
            productComments = new HashSet<productComment>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(400)]
        public string UserPass { get; set; }

        [StringLength(40)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string UserAddress { get; set; }

        public byte? UserVerified { get; set; }

        [StringLength(20)]
        public string UserVeificationCode { get; set; }

        [StringLength(20)]
        public string Userphone { get; set; }

        public bool UserActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UserDataCreate { get; set; }

        public byte? UserYearOld { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productComment> productComments { get; set; }
    }
}
