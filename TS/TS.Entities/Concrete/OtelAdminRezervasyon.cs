using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class OtelAdminRezervasyon : ITable
    {
        public int Id { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public string Cinsiyet { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public OtelOda OtelOdas { get; set; }
        public int OtelOdaId { get; set; }
        public bool Durum { get; set; }
        public double OdenecekTutar { get; set; }
    }
}
