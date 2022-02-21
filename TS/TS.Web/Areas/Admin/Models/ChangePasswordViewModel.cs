using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Mevcut şifre boş geçilemez.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifre boş geçilemez.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Parolalar uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
