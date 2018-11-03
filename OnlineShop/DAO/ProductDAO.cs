using OnlineShop.Models;
using OnlineShop.Models.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineShop.DAO
{
    public class ProductDAO
    {
        DataWeb data;
        public ProductDAO()
        {
            data = new DataWeb();
        }

        public List<ProductModel> GetProductByCategory(int ID)
        {
            var ListPro = data.Products.Where(q => q.ProductCategory.CategoryID == ID).OrderBy(q => q.ProductHot).ToList();
            if (ListPro.Count > 10)
            {
                ListPro = ListPro.Take(10).ToList();
            }
            List<ProductModel> Products = new List<ProductModel>();
            foreach (var item in ListPro)
            {
                List<string> listImage = new List<string>();
                var listXml = XElement.Parse(item.Images);
                foreach (var image in listXml.Elements())
                {
                    listImage.Add(image.Value);
                }
                Products.Add(new ProductModel()
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    ProductColor = item.ProductColor,
                    ProductPrice = item.ProductPrice,
                    ProductDetails = item.ProductDetails,
                    ProductQuality = item.ProductQuality,
                    ProductQuantity = item.ProductQuantity,
                    ProductSale = item.ProductSale,
                    ProductSize = item.ProductSize,
                    ProductImages = listImage
                });
            }

            return Products;
        }
        public List<ProductModel> GetProductByGroupCategory(int ID)
        {
            var ListPro = data.Products.Where(q => q.ProductCategory.GroupCategory.ID == ID).OrderBy(q => q.ProductHot).ToList();
            if (ListPro.Count > 10)
            {
                ListPro = ListPro.Take(10).ToList();
            }
            List<ProductModel> Products = new List<ProductModel>();
            foreach (var item in ListPro)
            {
                List<string> listImage = new List<string>();
                var listXml = XElement.Parse(item.Images);
                foreach (var image in listXml.Elements())
                {
                    listImage.Add(image.Value);
                }
                Products.Add(new ProductModel()
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    ProductColor = item.ProductColor,
                    ProductPrice = item.ProductPrice,
                    ProductDetails = item.ProductDetails,
                    ProductQuality = item.ProductQuality,
                    ProductQuantity = item.ProductQuantity,
                    ProductSale = item.ProductSale,
                    ProductSize = item.ProductSize,
                    ProductImages = listImage
                });
            }

            return Products;
        }

        public List<ProductModel> GetProductByHot()
        {
            var ListPro = data.Products.OrderBy(q => q.ProductHot).Take(4).ToList();
           
            List<ProductModel> Products = new List<ProductModel>();
            foreach (var item in ListPro)
            {
                List<string> listImage = new List<string>();
                var listXml = XElement.Parse(item.Images);
                foreach (var image in listXml.Elements())
                {
                    listImage.Add(image.Value);
                }
                Products.Add(new ProductModel()
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    ProductColor = item.ProductColor,
                    ProductPrice = item.ProductPrice,
                    ProductDetails = item.ProductDetails,
                    ProductQuality = item.ProductQuality,
                    ProductQuantity = item.ProductQuantity,
                    ProductSale = item.ProductSale,
                    ProductSize = item.ProductSize,
                    ProductImages = listImage
                });
            }

            return Products;
        }

        public List<ProductCategory> GetCategoryMan()
        {
            return data.ProductCategories.Where(q => q.GroupCategory.IDType == 1).ToList();
        }

        public List<ProductCategory> GetCategoryWoman()
        {
            return data.ProductCategories.Where(q => q.GroupCategory.IDType == 2).ToList();
        }

        public ProductModel GetProductByID(int id)
        {
            var pro = data.Products.SingleOrDefault(q => q.ProductID == id);
            List<string> listImage = new List<string>();
            var listXml = XElement.Parse(pro.Images);
            foreach (var item in listXml.Elements())
            {
                listImage.Add(item.Value);
            }
            return new ProductModel()
            {
                ProductID = pro.ProductID,
                ProductName = pro.ProductName,
                ProductColor = pro.ProductColor,
                ProductPrice = pro.ProductPrice,
                ProductDetails = pro.ProductDetails,
                ProductQuality = pro.ProductQuality,
                ProductQuantity = pro.ProductQuantity,
                ProductSale = pro.ProductSale,
                ProductSize = pro.ProductSize,
                ProductImages = listImage
            };

        }
        public List<ProductCategory> GetCategory()
        {
            return data.ProductCategories.Take(2).ToList();
        }
        public List<GroupCategory> getlistGroupCategory(int id)
        {
            return data.GroupCategories.Where(q=>q.IDType== id).ToList();
        }
        public List<ProductCategory> getListCategory()
        {
            return data.ProductCategories.ToList();

        }
        public ProductCategory GetCategoryByID(int ID)
        {
            return data.ProductCategories.SingleOrDefault(q => q.IDGroup == ID);
        }

    }
}

