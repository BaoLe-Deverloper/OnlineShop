using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Model
{
    public class GroupCategoryModel
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public string NAME { get; set; }
        [Required(ErrorMessage = "Hãy nhập mục này.")]
        public string TypeName { get; set; }
    }
}