using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserAdmin user)
        {
            if (ModelState.IsValid)
            {
                var status = new UserAdminDAO().Login(user.UserName, user.UserPass);
                if (status == "True")
                {
                    Session["Admin"] = user.UserName;
                    return RedirectToAction("Index", "HomeAd");
                }
                else ModelState.AddModelError("", status);
            }
            

            return View();
        }
        public ActionResult Logout ()
        {
            FormsAuthentication.SignOut();//Hủy tất cả cooki session mà đã tạo
            Session.Remove("Admin");
            return RedirectToAction("Index", "Login");
        }
    }
}