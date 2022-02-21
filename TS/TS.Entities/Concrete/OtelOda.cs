using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class OtelOda : ITable
    {
        public int Id { get; set; }
        public string OdaTipi { get; set; }
        public string IcerikBilgisi { get; set; }
        public string Picture { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public string Bilgi { get; set; }
        public string OtelOdaOzellik { get; set; }
        public string ParaBirimi { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public double? Fiyat { get; set; }
        public List<OtelOdaImage> OtelOdaImages { get; set; }
        public List<OtelOdaOzellik> OtelOdaOzelliks { get; set; }
        public List<OtelRezervasyon> OtelRezervasyons { get; set; }
        public List<OtelAdminRezervasyon> OtelAdminRezervasyons { get; set; }

    }
}
