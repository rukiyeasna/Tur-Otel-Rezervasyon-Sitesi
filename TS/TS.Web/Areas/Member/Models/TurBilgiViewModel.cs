using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class TurBilgiViewModel
    {
        public int TurId { get; set; }
        public string TurAltKategori { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public double? Fiyat { get; set; }
        public string Picture { get; set; }
        public string GidilecekYerler { get; set; }
        public string TurBasligi { get; set; }
        public string FiyataDahilHizmetler { get; set; }
        public string FiyataDahilOlmayanHizmetler { get; set; }
        public string TurProgrami { get; set; }
        public string TurKalkisNoktalari { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public bool PopulerDurum { get; set; }
        public string Ulasim { get; set; }
        public IFormFile ResimDosyasi { get; set; }
    }
}
