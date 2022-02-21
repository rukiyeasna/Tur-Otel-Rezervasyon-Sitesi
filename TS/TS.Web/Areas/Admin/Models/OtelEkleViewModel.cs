using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class OtelEkleViewModel
    {
        public int OtelBilgiId { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public double? CiftKisilikOda { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public double? IlaveYatak { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public double? TekKisilikOda { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public double? Cocuk_3_6_Yas { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        public double? Cocuk_7_12_Yas { get; set; }
        public double Aciklama { get; set; }
        public int TurId { get; set; }
        [Required(ErrorMessage = "Otel bilgisi boş geçilemez")]
        public string FiyatTanimi { get; set; }
        //public TurBilgileri TurBilgileris { get; set; }
    }
}
