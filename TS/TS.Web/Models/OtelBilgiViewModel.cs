using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Models
{
    public class OtelBilgiViewModel
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
    }
}
