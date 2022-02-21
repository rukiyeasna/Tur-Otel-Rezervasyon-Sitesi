using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class OtelOdaOzellikViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Özellik alanı boş geçilemez")]
        public string Ozellik { get; set; }
        public int OtelOdaId { get; set; }
        public OtelOda OtelOdas { get; set; }
    }
}
