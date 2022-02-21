using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Models
{
    public class OtelOdaListViewModel
    {
        public int Id { get; set; }
        public string OdaTipi { get; set; }
        public string IcerikBilgisi { get; set; }
        public string OtelAd { get; set; }
        public string Picture { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public string Bilgi { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public double? Fiyat { get; set; }
        public List<OtelOdaImage> OtelOdaImages { get; set; }
        public string OtelOdaOzellik { get; set; }
        public string OtelOzellik { get; set; }
        public string Sehir { get; set; }
    }
}
