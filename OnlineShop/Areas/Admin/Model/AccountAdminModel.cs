 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Model
{
    public class AccountAdminModel
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(100)]
        [Display (Name ="Tên Tài Khoản")]
        [Required(ErrorMessage ="Bạn chưa nhập Tên")]
        public string UserName { get; set; }

        [Display(Name = "Quyền User")]
        public int? IDQuyen { get; set; }
        [Display(Name = "Hòm Thư điện tử")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ Email")]
        [StringLength(50)]
        public string UserEmail { get; set; }
        [Display(Name = "Ngày Tạo Tài Khoản")]
        public DateTime? UserDateCreate { get; set; }
        [Display(Name = "Trạng thái Kích Hoạt")]
        public bool UserActive { get; set; }
        [Display(Name = "Tiền Lượng")]
        public double UserLuong { get; set; }
        [Display(Name = "Ảnh")]
        [StringLength(100)]
        public string UserImage { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string UserAddress { get; set; }
      
        [Display(Name = "Số điện thoại")]
        public string UserPhone { get; set; }

        public string QuyenUser { get; set; }

    }
}