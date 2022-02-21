using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class OtelOdaViewModel
    {
        public int Id { get; set; }
        public string OdaTipi { get; set; }
        public string OtelAd { get; set; }
        public string IcerikBilgisi { get; set; }
        public string Picture { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public string Bilgi { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public IFormFile ResimDosyasi { get; set; }
        public double? Fiyat { get; set; }
        public string OtelOdaOzellik { get; set; }
        public string ParaBirimi { get; set; }
    }
}
