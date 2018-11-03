using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Model
{
    public class ProductModel
    {
        public int ProductID { get; set; }

       
        [StringLength(50)]
        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public double ProductPrice { get; set; }

        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public double? ProductSize { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="dd/MM/yyyy HH:mm")]
        
        public DateTime? ProductUpdateDate { get; set; }

       
        public int? ProductQuantity { get; set; }

      
        [StringLength(1000)]
        public string ProductDetails { get; set; }

       
        [StringLength(200)]
        public string ProductLocation { get; set; }

       
        public int? ProductCategoryID { get; set; }

        

      

        [StringLength(50)]
      
        public string ProductQuality { get; set; }

        
        [StringLength(30)]
        public string ProductColor { get; set; }

      
        public byte? ProductHot { get; set; }
      
        public List<string> ListImage { set; get; }
        public string img { set; get; }
        
      
    }
}