using OnlineShop.Models.ClientModel;
using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class CartProductsController : Controller
    {
        // GET: CartProducts
        public ActionResult Index()
        {
            return View();
        }
        ProductDAO productDAO = new ProductDAO();
        [HttpPost]
        public ActionResult AddCart(int ID, int Quantity)
        {
            if (Session[Common.Const.CartProduct] == null)
            {
                Session[Common.Const.CartProduct] = new List<CartProduct>();
            }
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var ID = serializer.Deserialize<int>(id);
            var product = productDAO.GetProductByID(ID);
            List <CartProduct> ListProduct = Session[Common.Const.CartProduct] as List<CartProduct>;
            if(ListProduct.Exists(q=> q.ProductID == ID))
            {
                var item = ListProduct.Find(q=>q.ProductID== ID);
                item.Quantity += Quantity;
                
            }
          else
            {
                ListProduct.Add(new CartProduct() { ProductID = ID, Quantity = Quantity, Product = product });
            };
            Session[Common.Const.CartProduct] = ListProduct;
            var SumPrice = ListProduct.Sum(q => q.Quantity * q.Product.ProductPrice);
            var SumItem = ListProduct.Count;
            return Json(new { Sum = SumPrice, QuantityItem = SumItem }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CartProduct> ListProduct = Session[Common.Const.CartProduct] as List<CartProduct>;
            ListProduct.Remove(ListProduct.SingleOrDefault(q => q.ProductID == id));
            return RedirectToAction("Index", "CartProducts");
        }
    }
    
}