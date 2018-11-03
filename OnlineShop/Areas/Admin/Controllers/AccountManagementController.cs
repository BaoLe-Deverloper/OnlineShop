using OnlineShop.Areas.Admin.Model;
using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountManagementController : BaseController
    {
        // GET: Admin/AccountManagement
        public ActionResult Index()
        {
            return View();
        }
        UserAdminDAO dbUser = new UserAdminDAO();
        [HttpGet]
        public JsonResult GetTable ()
        {
            var data = dbUser.GetlistAccount();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult AddOrEditAccount (int id = 0)
        {
            
            ViewBag.ListChucVu = dbUser.getListQuyen();
            AccountAdminModel accountAdmin = new AccountAdminModel();
            if (id != 0)
                accountAdmin = dbUser.GetAccountById(id);
            return View(accountAdmin); 
        }

        [HttpPost]
        public ActionResult AddOrEditAccount(AccountAdminModel account)
        {
           
            bool result = dbUser.AddOrEdit(account);

            return Json(new {Result = result, message = "Lưu Thành Công!" },JsonRequestBehavior.AllowGet );
        }

        [HttpGet]
        public ActionResult AccountView(int id)
        {
            var acc = dbUser.GetAccountById(id);
            ViewBag.Quyen = dbUser.GetQuyenByID(acc.IDQuyen);
            return View(acc);
        }
        [HttpPost]
        public ActionResult Delete (int id)
        {
            var result = dbUser.Delete(id);
            return Json(new { Result = result, message = "Xóa Thành Công." }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Active(int id) 
        {
            bool result ;
            try
            {
               dbUser.Active(id);
                result = true;
            }
           catch(Exception)
            {
                result = false;
            }
              
            return Json(new { Result = result, message = "Thành Công." }, JsonRequestBehavior.AllowGet);
        }


    }
}