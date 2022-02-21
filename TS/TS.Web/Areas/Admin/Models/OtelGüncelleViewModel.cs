﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class OtelGüncelleViewModel
    {
        public int OtelId { get; set; }
        [Required(ErrorMessage = "Şehir alanı boş geçilemez")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Otel Adı boş geçilemez")]
        public string OtelAd { get; set; }
        public string Picture { get; set; }
        public IFormFile ResimDosyasi { get; set; }
        public string OtelOzellik { get; set; }
        public string Anagrup { get; set; }
        public string Vize { get; set; }
    }
}
