using OnlineShop.Areas.Admin.Model;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineShop.DAO
{
    public class ProductAdminDao
    {
        DataWeb data;
        public ProductAdminDao()
        {
            data = new DataWeb();
            data.Configuration.ProxyCreationEnabled = false;
        }
        public List<ProductModel> GetListProduct()
        {
            var listproduct = data.Products.OrderBy(q => q.ProductUpdateDate).ToList();
            List<ProductModel> productModels = new List<ProductModel>();
            foreach(Product product in listproduct)
            {
                var listIElement = XElement.Parse(product.Images);
                List<string> ListImage = new List<string>();
                string img = listIElement.Elements().ToList()[0].Value;
              
                productModels.Add(new ProductModel()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductSize = product.ProductSize,
                    ProductQuality = product.ProductQuality,
                    ProductUpdateDate = product.ProductUpdateDate,
                    ProductColor = product.ProductColor,
                    ProductCategoryID = product.ProductCategoryID,
                    ProductDetails = product.ProductDetails,
                    ProductHot = product.ProductHot,
                    ProductLocation = product.ProductLocation,
                    ProductQuantity = product.ProductQuantity,
                    img = img
                });
            }

            return productModels;
        }

        public List<ProductCategory> GetCategory()
        {
            return data.ProductCategories.ToList();

        }
        public bool UpdateProduct(Product product)
        {
            try
            {
              Product old =  data.Products.SingleOrDefault(q => q.ProductID == product.ProductID);
                old.Images = product.Images;
                old.ProductName = product.ProductName;
                old.ProductCategoryID = product.ProductCategoryID;
                old.ProductPrice = product.ProductPrice;
                old.ProductColor = product.ProductColor;
                old.ProductDetails = product.ProductDetails;
                old.ProductLocation = product.ProductLocation;
                old.ProductUpdateDate = product.ProductUpdateDate;
                old.ProductQuality = product.ProductQuality;
                old.ProductQuantity = product.ProductQuantity;
                 old.ProductSize = product.ProductSize;

                data.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool AddProduct(Product newproduct)
        {
            try
            {
                data.Products.Add(newproduct);
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ProductModel getProductbyID(int id)
        {
            var product = data.Products.SingleOrDefault(q => q.ProductID == id);
            var listIElement = XElement.Parse(product.Images);
            List<string> ListImage = new List<string> (); 
            foreach(XElement item in listIElement.Elements())
            {
                ListImage.Add(item.Value);
            }
            return new ProductModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductSize = product.ProductSize,
                ProductQuality = product.ProductQuality,
                ProductUpdateDate = product.ProductUpdateDate,
                ProductColor = product.ProductColor,
                ProductCategoryID = product.ProductCategoryID,
                ProductDetails = product.ProductDetails,
                ProductHot = product.ProductHot,
                ProductLocation = product.ProductLocation,
                ProductQuantity = product.ProductQuantity,
                ListImage = ListImage
            };
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                data.Products.Remove(data.Products.SingleOrDefault(q => q.ProductID ==id));
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}