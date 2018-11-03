namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            productComments = new HashSet<productComment>();
        }

        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public double? ProductSize { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductUpdateDate { get; set; }

        public int? ProductQuantity { get; set; }

        [StringLength(1000)]
        public string ProductDetails { get; set; }

        [StringLength(200)]
        public string ProductLocation { get; set; }

        public int? ProductCategoryID { get; set; }

        public double ProductSale { get; set; }

        public int? ProductCommentID { get; set; }

        [StringLength(50)]
        public string ProductQuality { get; set; }

        [StringLength(30)]
        public string ProductColor { get; set; }

        public byte? ProductHot { get; set; }

        public byte? ProductEvaluation { get; set; }

        public int? IDage { get; set; }

        public int? IDNhanvien { get; set; }

        [Column(TypeName = "xml")]
        public string Images { get; set; }

        public virtual age age { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productComment> productComments { get; set; }

        public virtual UserAdmin UserAdmin { get; set; }
    }
}
