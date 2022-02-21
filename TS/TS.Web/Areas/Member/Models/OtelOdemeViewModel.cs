using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Member.Models
{
    public class OtelOdemeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Tc alanı boş geçilemez")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tc kimlik numranız 11 karakter olmalıdır")]
        public string Tc { get; set; }
        [Required(ErrorMessage = "Cinsiyet alanı boş geçilemez")]
        public string Cinsiyet { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppUserId { get; set; }
        public OtelOda OtelOdas { get; set; }
        public int OtelOdaId { get; set; }
        public bool Durum { get; set; }
        public double OdenenTutar { get; set; }
        //public string PaymentId { get; set; }
        //public string PaymentToken { get; set; }
        //public string ConversationId { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV { get; set; }
        public string CartName { get; set; }
        public string CartNumber { get; set; }
    }
}
