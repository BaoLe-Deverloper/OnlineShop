using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Model
{
    public class ShopInfoModel
    {
        public string ShopName { get; set; }
        public string ShopEmail { get; set; }
        public string ShopPhone { get; set; }
        public string ShopFacebook { get; set; }
        public string ShopAddress { get; set; }
        public string ShopLogo { get; set; }
        public string ShopMainPanel { get; set; }
        public string ShopImageSale1 { get; set; }
        public string ShopImageSale2 { get; set; }
        public string ShopImageSale { get; set; }
        public ShopMainSale ShopMainSale { get; set; }


    }

    public struct ShopMainSale {
        private string SaleName;
        private string SaleTitel;
        private DateTime SaleBeginDate;
        private DateTime SaleEndDate;
    }

}