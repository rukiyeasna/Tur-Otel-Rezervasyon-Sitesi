using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class AdminUserAddViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}
