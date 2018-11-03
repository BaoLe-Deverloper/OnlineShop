using OnlineShop.Areas.Admin.Model;
using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        ProductAdminDao productDAO = new ProductAdminDao();
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gettable()
        {
            var list = productDAO.GetListProduct();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            SetViewBag();
            ProductModel product = new ProductModel();
            if (id == 0)
            {
                DateTime t = DateTime.Now;
                product.ProductUpdateDate = t;

            }
            else
            {
                product = productDAO.getProductbyID(id);
            }
            return View(product);
        }

        public void SetViewBag(int? seletedId = null)
        {
            var listCate = productDAO.GetCategory();

            ViewBag.CateList = listCate;
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddOrEditProduct(string images, string newproduct)
        {
            bool result = false;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var product = (ProductModel)serializer.Deserialize<ProductModel>(newproduct);
            var ListImage = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");
            foreach (string item in ListImage)
            {
                int n = item.LastIndexOf("/Assets");
                string newitem =  item.Substring(n);
                XElement image = new XElement("Image", newitem);
                xElement.Add(image);
            }
            var admin = (Session["Admin"]).ToString();
            Product Newproduct = new Product()
            {
                ProductID = product.ProductID,
                Images = xElement.ToString(),
                ProductName = product.ProductName,
                ProductCategoryID = product.ProductCategoryID,
                ProductPrice = product.ProductPrice,
                ProductColor = product.ProductColor,
                ProductDetails = product.ProductDetails,
                ProductLocation = product.ProductLocation,
                ProductUpdateDate = product.ProductUpdateDate,
                ProductQuality = product.ProductQuality,
                ProductQuantity = product.ProductQuantity,
                ProductSize = product.ProductSize,

                IDNhanvien = new UserAdminDAO().GetAdminByName(admin).UserID,
                ProductHot = product.ProductHot

            };
            if (product.ProductID == 0)
            {
                result = productDAO.AddProduct(Newproduct);
            }
            else
                result = productDAO.UpdateProduct(Newproduct);

            return  Json(new {Result = result}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool Result = productDAO.DeleteProduct(id);


            return Json(new { success = Result, message = "Xóa thành công !" }, JsonRequestBehavior.AllowGet);
        }
    }
}