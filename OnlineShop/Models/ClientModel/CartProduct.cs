using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ClientModel
{
    [Serializable]
    public class CartProduct
    {
        public int ProductID { set; get; }
        public int  Quantity { set; get; }
        public ProductModel Product { set; get; }
    }
}