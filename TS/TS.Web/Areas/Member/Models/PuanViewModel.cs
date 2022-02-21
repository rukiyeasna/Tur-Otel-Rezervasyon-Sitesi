using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class PuanViewModel
    {
        public int OtelPuanId { get; set; }
        public double FiyatDeger { get; set; }
        public double HizmetDeger { get; set; }
        public double TemizDeger { get; set; }
        public double PersonelDeger { get; set; }
        public double OdaDeger { get; set; }
        public double YiyecekDeger { get; set; }
        public double Ortalama { get; set; }
        public double Toplam { get; set; } 
        public int OtelId { get; set; }
        public string Yorum { get; set; }
        public string Username { get; set; }
    }
}
