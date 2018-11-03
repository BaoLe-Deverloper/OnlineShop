using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductsClientController : Controller
    {
        // GET: Products
        ProductDAO productDAO = new ProductDAO();
        public ActionResult Categories(int id)
        {
            var res = productDAO.getlistGroupCategory(id);
            return PartialView(res);
        }

        public ActionResult Sort()
        {
            return PartialView();
        }
        public ActionResult ProductDetails(int id)
        {
            var product = productDAO.GetProductByID(id);
            return View(product);
        }

        public ActionResult ShowProducts()
        {
            ViewBag.Man = productDAO.GetProductByGroupCategory(1);
            ViewBag.Woman = productDAO.GetProductByGroupCategory(2);
            ViewBag.PhuKienNam = productDAO.GetProductByGroupCategory(3);
            ViewBag.PhuKienNu = productDAO.GetProductByGroupCategory(4);
            //ViewBag.Giay
            return PartialView();
        }
        public ActionResult NewProducts()
        {
            return PartialView(productDAO.GetProductByHot());
        }

        

        public ActionResult ProductMan(int id)
        {
          
            var Products = productDAO.GetProductByCategory(id);
            return View(Products);
        }
        public ActionResult ProductWoman(int id)
        {

            var Products = productDAO.GetProductByCategory(id);
            return View(Products);
        }
        
    }
}