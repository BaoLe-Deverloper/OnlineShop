using OnlineShop.DAO;
using OnlineShop.Models.ClientModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
           
            return View();
        }

        public ActionResult Menubanner()
        {
            ViewBag.CategoryMan = new ProductDAO().GetCategoryMan();
            ViewBag.CategoryWoman = new ProductDAO().GetCategoryWoman();
            return PartialView();
        }
        [HttpPost]
        public ActionResult ValidateUser ( string UserName, string password,  bool rememberme)
        { 
          
            var status = new UserDAO().Login(UserName, password);
            if(status=="Client")
            {
                FormsAuthentication.SetAuthCookie(UserName, rememberme);
                Session["User"] = UserName;
            }
           return Json( status,
               JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateUser ( string UserName, string Email, string pass, string Config)
        {
            var status = "Bạn Chưa nhập đủ thông tin.";
            if(ModelState.IsValid)
            {
                if (pass == Config)
                {
                    if (!new UserDAO().Exists(UserName))
                    {
                        status = new UserDAO().SignUp(UserName, Email, pass);
                    }
                    else
                        status = "Tên Tài Khoản Đã tồn tại .";
                }
                else status = "Mật Khẩu xác nhận không đúng.";
            }
           
            
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {

            return PartialView();
        }

        public ActionResult SignUp()
        {

            return PartialView();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();//Hủy tất cả cooki session mà đã tạo
            Session.Remove("User");
            return RedirectToAction("Home", "Home");
        }
        public ActionResult footer()
        {
            
            ShopInfo shopInfo = new ShopInfo() { Name = ConfigurationManager.AppSettings["ShopName"],
                ImageLogo = ConfigurationManager.AppSettings["ShopImageLogo"],
                PhoneNumber = ConfigurationManager.AppSettings["ShopPhone"],
                Facebook = ConfigurationManager.AppSettings["ShopFacebook"],
                Address = ConfigurationManager.AppSettings["ShopAddress"],
                Info = ConfigurationManager.AppSettings["ShopInfo"],
                Email = ConfigurationManager.AppSettings["ShopName"]
            };

            return PartialView(shopInfo);
        }
    }
}