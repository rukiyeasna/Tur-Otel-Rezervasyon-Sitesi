using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class OtelBilgileri : ITable
    {
        public int OtelBilgiId { get; set; }
        public double? CiftKisilikOda { get; set; }
        public double? IlaveYatak { get; set; }
        public double? TekKisilikOda { get; set; }
        public double? Cocuk_3_6_Yas { get; set; }
        public double? Cocuk_7_12_Yas { get; set; }
        public double Aciklama { get; set; }
        public string FiyatTanimi { get; set; }
        public int TurId { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        public List<Rezervasyon> Rezervasyons { get; set; }
        public List<AdminRezervasyon> AdminRezervasyons { get; set; }
    }
}
