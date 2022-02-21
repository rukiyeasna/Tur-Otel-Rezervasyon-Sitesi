using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int TurId { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        [Required(ErrorMessage = "Resim alanı boş geçilemez")]
        public IFormFile ResimDosyasi { get; set; }
    }
}
