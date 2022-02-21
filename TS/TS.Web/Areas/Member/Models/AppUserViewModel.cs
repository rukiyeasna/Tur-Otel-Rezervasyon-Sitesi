using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class AppUserViewModel
    {
        public int Id { get; set; }
        //[Display(Name = "Adınız :")]
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        //[Display(Name = "Soyadınız :")]
        //[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }
      
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        public string Username { get; set; }
        //[Display(Name = "Email :")]
        //[Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
    }
}
