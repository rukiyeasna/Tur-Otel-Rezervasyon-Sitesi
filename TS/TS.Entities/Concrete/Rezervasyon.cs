using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class Rezervasyon : ITable
    {
        public int Id { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string Yad { get; set; }
        public string Ysoyad { get; set; }
        public string Ytc { get; set; }
        public int YetiskinSayisi { get; set; }
        public int CocukSayisi { get; set; }
        public string Ycinsiyet { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        public int TurId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppUserId { get; set; }
        public OtelBilgileri OtelBilgileris { get; set; }
        public int OtelId { get; set; }
        public bool Durum { get; set; }
        public double OdenenTutar { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public string PaymentId { get; set; }
        public string PaymentToken { get; set; }
        public string ConversationId { get; set; }
    }
}
