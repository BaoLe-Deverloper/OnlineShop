using OnlineShop.Models;
using OnlineShop.Models.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OnlineShop.DAO
{
    public class UserDAO
    {
        DataWeb data;
        public UserDAO()
        {
            data = new DataWeb();

        }
        public List<User> GetListUser()
        {
            return data.Users.ToList();
        }

        public void DeleteUser(int ID)
        {
            try
            {
                var User = data.Users.Find(ID);
                data.Users.Remove(User);
                data.SaveChanges();
            }
            catch (Exception e)
            {

            }
          
        }
        public bool ActiveUser(int ID)
        {
            var user = data.Users.SingleOrDefault(q => q.UserID == ID);
            user.UserActive = !user.UserActive;
            data.SaveChanges();
            return user.UserActive;
        }

        public string Login (string UserName, string Pass)
        {
            Pass = GetMD5Hash(Pass);
            var User = data.Users.SingleOrDefault(q => q.UserName == UserName);
            if (User == null)
                return "Không tồn tại tài khoản này.";
            else
            {
                if (User.UserPass == Pass)
                  
                {
                    if (User.UserActive == true)
                        return "Client";
                    else
                        return "Tài khoản này chưa được kích hoạt";
                }
                else return "Mật khẩu sai";



            }

        }

        public bool Exists(string UserName )
        {
            var user = data.Users.SingleOrDefault(q=>q.UserName==UserName);
            if (user != null)
                return true;
            else return false;
        }

        public string SignUp (string Name, string Email, string Pass)
        {
            DateTime t = DateTime.Now;
            User newUser = new User() { UserName = Name, UserEmail = Email, UserPass = GetMD5Hash(Pass), UserDataCreate = t };
            try
            {
                data.Users.Add(newUser);
                data.SaveChanges();
                return "True";
            }
            catch (Exception e)
            {
                return e.Message;
            }
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