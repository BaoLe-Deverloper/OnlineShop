using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "CheckOut",
               url: "Thanh-toan",
               defaults: new { controller = "CartProducts", action = "CheckOut", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "CartProduct",
                url: "Gio-hang",
                defaults: new { controller = "CartProducts", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetails",
                url: "chi-tiet-san-pham-{id}",
                defaults: new { controller = "ProductsClient", action = "ProductDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "ProductMan",
              url: "Thoi-trang-Nam-{id}",
              defaults: new { controller = "ProductsClient", action = "ProductMan", id = UrlParameter.Optional }
          );
            routes.MapRoute(
            name: "ProductWoman",
            url: "Thoi-trang-Nu-{id}",
            defaults: new { controller = "ProductsClient", action = "ProductWoman", id = UrlParameter.Optional }
        );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
           );

        }
    }
}
