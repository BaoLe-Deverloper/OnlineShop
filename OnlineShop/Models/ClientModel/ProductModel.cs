using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ClientModel
{
    public class ProductModel
    {
        public int ProductID { get; set; }

       
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public double? ProductSize { get; set; }

       
        public DateTime? ProductUpdateDate { get; set; }

        public int? ProductQuantity { get; set; }


        public string ProductDetails { get; set; }


        public int? ProductCategoryID { get; set; }

        public double ProductSale { get; set; }

        public int? ProductCommentID { get; set; }


        public string ProductQuality { get; set; }


        public string ProductColor { get; set; }

        public byte? ProductHot { get; set; }

        public byte? ProductEvaluation { get; set; }

        public int? IDage { get; set; }

        public List<string> ProductImages { get; set; }

       
    }
}