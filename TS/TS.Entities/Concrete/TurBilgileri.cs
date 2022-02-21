using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class TurBilgileri :ITable
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
        public string Ulasim { get; set; }
        public string Anagrup { get; set; }
        public string ParaBirimi { get; set; }
        public string Vize { get; set; }
        public bool Durum { get; set; }
        public bool PopulerDurum { get; set; }
        public List<OtelBilgileri> OtelBilgileris { get; set; }
        public List<Favori> Favoris { get; set; }
        public List<Images> Images { get; set; }
        public List<Rezervasyon> Rezervasyons { get; set; }
        public List<TurOzellik> TurOzelliks { get; set; }
        public List<AdminRezervasyon> AdminRezervasyons { get; set; }

    }
}
