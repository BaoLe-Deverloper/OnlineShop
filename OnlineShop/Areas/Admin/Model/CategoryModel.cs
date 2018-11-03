using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Model
{
    public class CategoryModel
    {
        public int IDCategory { get; set; }
        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public string GroupCategory { get; set; }
        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public string Category { get; set; }
    }
}