namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class productComment
    {
        [Key]
        public int CommentID { get; set; }

        public int? CommentUserID { get; set; }

        public int? CommentProductID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CommentDate { get; set; }

        [StringLength(200)]
        public string CommentContent { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
