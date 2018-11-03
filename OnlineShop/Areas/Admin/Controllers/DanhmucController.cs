using OnlineShop.DAO;
using OnlineShop.Models;
using OnlineShop.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class DanhmucController : BaseController
    {
        DanhMucDAO danhMucDAO = new DanhMucDAO();
        // GET: Admin/Danhmuc

        public ActionResult Category()
        {
         
            return View();
        }
        public ActionResult CategoryGroup()
        {

            return View();
        }
        [HttpGet]
        public ActionResult GetTableGroupCategory()
        {
            var listType = danhMucDAO.GetListGroupCategory();

            return Json(new { data = listType }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetTableCate()
        {
            var listcate = danhMucDAO.GetListCategory();

            return Json(new { data = listcate }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteGroupCategory(int id)
        {
            var status = "Xóa Thất Bại";
            var result = danhMucDAO.DeleteGroupCategory(id);
            if(result== true)
            {
                status = "Xóa Thành Công";
            }
            return Json (new {Result = result, message = status }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            var result = danhMucDAO.DeleteProductCategory(id);
            var status = "Xóa Thất Bại";
            if (result == true)
            {
                status = "Xóa Thành Công";
            }
            return Json(new { Result = result, message = status }, JsonRequestBehavior.AllowGet);
        }



      
       [HttpGet]
        public ActionResult AddOrEditGroupCategory(int id =0 )
        {
            SetViewBag();
            var typeProduct = new GroupCategory();
            if(id != 0)
            {
                typeProduct = danhMucDAO.GetGroupCategoryByID(id);
            }
            return View(typeProduct);
        }
      
        public void SetViewBag(int? seletedId = null)
        {
             
            
            ViewBag.ListGroup = danhMucDAO.GetListGroupCategory();
            ViewBag.ListType = danhMucDAO.GetListTypeGroup();
        }


        [HttpPost]
        public ActionResult AddOrEditGroupCategory (GroupCategory type)
        {
            bool result = false;
            string status = "Lưu Thất Bại!";
            if (type.ID == 0)
            {
                result = danhMucDAO.AddGroupCategory(type);
                status = "Lưu Thành Công!";
            }
            else
            {
                result = danhMucDAO.EditGroupCategory(type);
                status = "Lưu Thành Công!";
            }
            return Json(new { Result = result, message = status }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEditCategory(int id =0)
        {
            SetViewBag();
           
            var productCategory = new ProductCategory();
            if(id != 0)
            {
                productCategory = danhMucDAO.GetCategoryProductByID(id);
             
            }
            return View (productCategory);
        }

        [HttpPost]
        public ActionResult AddOrEditCategory(ProductCategory cate)
        {
            bool result = false;
            string status = "Lưu Thất Bại!";
            if (cate.CategoryID == 0)
            {

                result = danhMucDAO.AddProductCategory(cate);
                status = "Lưu Thành Công!";
            }
            else
            {
                result = danhMucDAO.EditProductCategory(cate);
                status = "Lưu Thành Công!";
            }
            return Json(new { Result = result, message = status }, JsonRequestBehavior.AllowGet);
        }
    }
    
}
