using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class RezerAdminViewModel
    {
        public int RezervasyonId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string Yad { get; set; }
        public string Ysoyad { get; set; }
        public string Ytc { get; set; }
        public string Ycinsiyet { get; set; }
        public int YetiskinSayisi { get; set; }
        public int CocukSayisi { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        public int TurId { get; set; }
        public OtelBilgileri OtelBilgileris { get; set; }
        public int OtelId { get; set; }
        public bool Durum { get; set; }
        public int OtelBilgiId { get; set; }
        public double? CiftKisilikOda { get; set; }
        public double? IlaveYatak { get; set; }
        public double? TekKisilikOda { get; set; }
        public double? Cocuk_3_6_Yas { get; set; }
        public double? Cocuk_7_12_Yas { get; set; }
        public double Aciklama { get; set; }
        public string FiyatTanimi { get; set; }
        public string TurAltKategori { get; set; }
        public string Picture { get; set; }
        public string TurBasligi { get; set; }
        public string ParaBirimi { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public double OdenecekTutar { get; set; }
    }
}
