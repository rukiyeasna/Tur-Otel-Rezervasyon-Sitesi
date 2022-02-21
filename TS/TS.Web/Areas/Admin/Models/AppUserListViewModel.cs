using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        //[Display(Name = "Adınız :")]
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        //[Display(Name = "Soyadınız :")]
        //[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }
        public string Username { get; set; }
        //[Display(Name = "Email :")]
        //[Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        //[Display(Name = "Resim :")]
        //public string Picture { get; set; }
    }
}
