using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class Otel : ITable
    {
        public int OtelId { get; set; }
        public string Sehir { get; set; }
        public string OtelAd { get; set; }        
        public string Picture { get; set; }
        public string OtelOzellik { get; set; }
        public string Anagrup { get; set; }
        public string Vize { get; set; }
        public List<OtelOda> OtelOdas { get; set; }
        public List<OtelImage> OtelImages { get; set; }
        public List<OtelOzellik> OtelOzelliks { get; set; }
        public List<OtelFavori> OtelFavoris { get; set; }
        public List<OtelRezervasyon> OtelRezervasyons { get; set; }
        public List<OtelAdminRezervasyon> OtelAdminRezervasyons { get; set; }
    }
}
