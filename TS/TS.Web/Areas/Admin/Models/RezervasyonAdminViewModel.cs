using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class RezervasyonAdminViewModel
    {
        public int RezervasyonId { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Yad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Ysoyad { get; set; }
        [Required(ErrorMessage = "Tc alanı boş geçilemez")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tc kimlik numranız 11 karakter olmalıdır")]
        public string Ytc { get; set; }
        [Required(ErrorMessage = "Cinsiyet alanı boş geçilemez")]
        public string Ycinsiyet { get; set; }
        public int YetiskinSayisi { get; set; }
        public int CocukSayisi { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        public int TurId { get; set; }
        //public AppUser AppUsers { get; set; }
        //public int AppUserId { get; set; }
        public OtelBilgileri OtelBilgileris { get; set; }
        public int OtelId { get; set; }
        public bool Durum { get; set; }
        public double OdenecekTutar { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
    }
}
