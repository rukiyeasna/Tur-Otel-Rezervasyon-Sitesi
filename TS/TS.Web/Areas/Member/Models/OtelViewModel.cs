using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class OtelViewModel
    {
        public int OtelBilgiId { get; set; }
        public double? CiftKisilikOda { get; set; }
        public double? IlaveYatak { get; set; }
        public double? TekKisilikOda { get; set; }
        public double? Cocuk_3_6_Yas { get; set; }
        public double? Cocuk_7_12_Yas { get; set; }
        public double Aciklama { get; set; }
        public int TurId { get; set; }
        public string FiyatTanimi { get; set; }
        public string TurAltKategori { get; set; }
        public string Picture { get; set; }
        public string TurBasligi { get; set; }
        public string ParaBirimi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
