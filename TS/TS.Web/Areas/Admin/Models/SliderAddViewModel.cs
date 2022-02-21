using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class SliderAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Resim alanı boş geçilemez")]
        public string Picture { get; set; }
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Resim alanı boş geçilemez")]
        public IFormFile ResimDosyasi { get; set; }
    }
}
