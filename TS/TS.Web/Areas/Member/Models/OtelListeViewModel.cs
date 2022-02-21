using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Member.Models
{
    public class OtelListeViewModel
    {
        public int OtelId { get; set; }
        public string Sehir { get; set; }
        public string OtelAd { get; set; }
        public string Picture { get; set; }
        public List<OtelOda> OtelOdas { get; set; }
        public List<OtelImage> OtelImages { get; set; }
        public string OtelOzellik { get; set; }
    }
}
