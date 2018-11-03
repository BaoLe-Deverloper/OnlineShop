using OnlineShop.Areas.Admin.Model;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace OnlineShop.DAO
{
    public class UserAdminDAO
    {
        DataWeb data;
        public UserAdminDAO()
        {
            data = new DataWeb();

        }

        public string Login(string UserName, string Pass)
        {
            var user = data.UserAdmins.SingleOrDefault(q => q.UserName == UserName);
            if (user == null)
                return "Không tồn tại tài khoản quản trị này.";
            else
            {
                if (user.UserPass == GetMD5Hash(Pass))
                {
                    if (user.UserActive == true)
                        return "True";
                    else
                        return "Tài khoản này chưa được kích hoạt hoặc đã bị khóa.";
                }
                else return "Mật khẩu không đúng.";
            }
        }
        public List<AccountAdminModel> GetlistAccount()
        {
            var list = data.UserAdmins.ToList();
            List<AccountAdminModel> listAccount = new List<AccountAdminModel>();

            foreach (UserAdmin item in list)
            {
                var Image = XElement.Parse(item.UserImage);
                listAccount.Add(new AccountAdminModel()
                {
                    UserID = item.UserID,
                    UserName = item.UserName,
                    UserEmail = item.UserEmail,
                    UserDateCreate = item.UserDateCreate,
                    UserPhone = item.UserPhone,
                    UserAddress = item.UserAddress,
                    UserLuong = item.UserLuong,
                    UserActive = item.UserActive,
                    IDQuyen = item.UserIDQuyen,
                    UserImage = Image.Value,
                    QuyenUser = data.Quyens.SingleOrDefault(q => q.ID == item.UserIDQuyen).QuyenUser
                    
                });
            }
            return listAccount;
        }

        public AccountAdminModel GetAccountByName(string Name)
        {
            var item = data.UserAdmins.SingleOrDefault(q => q.UserName == Name);
            var Image = XElement.Parse(item.UserImage);
            return new AccountAdminModel()
            {
                UserID = item.UserID,
                UserName = item.UserName,
                UserEmail = item.UserEmail,
                UserDateCreate = item.UserDateCreate,
                UserPhone = item.UserPhone,
                UserAddress = item.UserAddress,
                UserLuong = item.UserLuong,
                UserActive = item.UserActive,
                IDQuyen = item.UserIDQuyen,
                UserImage = Image.Value
            };
        }

        public AccountAdminModel GetAccountById(int id)
        {
            var item = data.UserAdmins.SingleOrDefault(q => q.UserID == id);
            var Image = XElement.Parse(item.UserImage);
            return new AccountAdminModel()
            {
                UserID = item.UserID,
                UserName = item.UserName,
                UserEmail = item.UserEmail,
                UserDateCreate = item.UserDateCreate,
                UserPhone = item.UserPhone,
                UserAddress = item.UserAddress,
                UserLuong = item.UserLuong,
                UserActive = item.UserActive,
                IDQuyen = item.UserIDQuyen,
                UserImage = Image.Value
            };
        }


        public bool Delete(int id)
        {
            try
            {
                var list = data.Products.Where(q => q.IDNhanvien == id).ToList();
                foreach(var item in list)
                {
                    item.IDNhanvien = null;
                }
                var listoder = data.Orders.Where(q => q.IDNhanVien == id).ToList();
                foreach (var item in listoder)
                {
                    item.IDNhanVien = null;
                }
                data.UserAdmins.Remove(data.UserAdmins.SingleOrDefault(q => q.UserID == id));

                data.SaveChanges();
                return true;

            }
            catch (Exception) { return false; }
        }
        public List<Quyen> getListQuyen ()
        {
            return data.Quyens.ToList();
        }

        public string GetQuyenByID (int? id)
        {
            if (id != null)
                return data.Quyens.SingleOrDefault(q => q.ID == id).QuyenUser;
            else
                return "Không Có Quyền";
        }

        public bool? Active (int id)
        {
         
                var Acc = data.UserAdmins.SingleOrDefault(q => q.UserID == id);
                Acc.UserActive = !Acc.UserActive;
                data.SaveChanges();
            return Acc.UserActive;

        }
        public bool AddOrEdit(AccountAdminModel accont)
        {
            try
            {
                var XmlImage = new XElement("Image", accont.UserImage);
                if (accont.UserID == 0)
                {
                    ////thêm account
                    UserAdmin userAdmin = new UserAdmin()
                    {
                        UserID = accont.UserID,
                        UserName = accont.UserName,
                        UserEmail = accont.UserEmail,
                        UserDateCreate = accont.UserDateCreate,
                        UserPhone = accont.UserPhone,
                        UserAddress = accont.UserAddress,
                        UserLuong = accont.UserLuong,
                        UserIDQuyen = accont.IDQuyen,
                        UserImage = XmlImage.ToString()
                    };
                    data.UserAdmins.Add(userAdmin);
                    data.SaveChanges();

                }
                else
                {
                    ///Sử tai khoản.
                    UserAdmin userAdmin = data.UserAdmins.SingleOrDefault(q => q.UserID == accont.UserID);
                    userAdmin.UserName = accont.UserName;
                    userAdmin.UserEmail = accont.UserEmail;
                    userAdmin.UserDateCreate = accont.UserDateCreate;
                    userAdmin.UserPhone = accont.UserPhone;
                    userAdmin.UserAddress = accont.UserAddress;
                    userAdmin.UserLuong = accont.UserLuong;
                    userAdmin.UserIDQuyen = accont.IDQuyen;
                    userAdmin.UserImage = XmlImage.ToString();
                    data.SaveChanges();
                }

                return true;

            }
            catch (Exception) { return false; }
        }

        public UserAdmin GetAdminByName(string Name)
        {
            return data.UserAdmins.SingleOrDefault(q => q.UserName == Name);

        }
        public static string GetMD5Hash(string value)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            byte[] data = md5Hasher.ComputeHash(Encoding.ASCII.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}