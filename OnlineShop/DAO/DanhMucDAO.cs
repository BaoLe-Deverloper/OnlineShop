using OnlineShop.Models;
using OnlineShop.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class DanhMucDAO
    {
        DataWeb data;
        public DanhMucDAO ()
        {
            data = new DataWeb();
            data.Configuration.ProxyCreationEnabled = false;
        }

        public List<GroupCategoryModel> GetListGroupCategory()
        {   
            var list = data.GroupCategories.ToList();
            var ListGroup = new List<GroupCategoryModel>();
            foreach (GroupCategory item in list)
            {
                GroupCategoryModel groupCategoryModel = new GroupCategoryModel() { ID = item.ID, NAME = item.NAME, TypeName = data.TypeGroups.Find(item.IDType).TypeName };
                ListGroup.Add(groupCategoryModel);
            }
            return ListGroup;
        }
        public List<CategoryModel> GetListCategory ()
        {
            var Cates = data.ProductCategories.ToList();
            var ListCate = new List<CategoryModel>();
            foreach ( ProductCategory item in Cates)
            {
                CategoryModel cate = new CategoryModel() { IDCategory = item.CategoryID, Category = item.CategoryName, GroupCategory = data.GroupCategories.Find(item.IDGroup).NAME};
                ListCate.Add(cate);
            }
            return ListCate;
        }
        public List<TypeGroup> GetListTypeGroup ()
        {
            return data.TypeGroups.ToList();
        }
        public GroupCategory GetGroupCategoryByID(int id)
        {
            return data.GroupCategories.SingleOrDefault(q => q.ID == id);
        }
        public ProductCategory GetCategoryProductByID(int id)
        {
            return data.ProductCategories.SingleOrDefault(q => q.CategoryID == id);
        }

        public bool DeleteGroupCategory(int id )
        {
            try
            {
                data.GroupCategories.Remove(data.GroupCategories.SingleOrDefault(q => q.ID == id));
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddGroupCategory(GroupCategory type)
        {
            try
            {
                data.GroupCategories.Add(type);
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditGroupCategory(GroupCategory Newtype)
        {
            try
            {
                var old = data.GroupCategories.SingleOrDefault(q => q.ID == Newtype.ID);
                old.NAME = Newtype.NAME;
                old.IDType = Newtype.IDType;
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteProductCategory(int id)
        {
            try
            {
                data.ProductCategories.Remove(data.ProductCategories.SingleOrDefault(q => q.CategoryID == id));
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddProductCategory(ProductCategory cate)
        {
            try
            {
                
                data.ProductCategories.Add(cate);
                data.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditProductCategory(ProductCategory newCate)
        {
            try
            {
                var old = data.ProductCategories.SingleOrDefault(q => q.CategoryID == newCate.CategoryID);
                old.IDGroup= newCate.IDGroup;
                old.CategoryName = newCate.CategoryName;
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