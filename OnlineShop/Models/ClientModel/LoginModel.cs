using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ClientModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Hãy nhập tài khoản của bạn.")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Hãy nhập Mật Khẩu của bạn.")]
        public string Pass { set; get; }
    }
}