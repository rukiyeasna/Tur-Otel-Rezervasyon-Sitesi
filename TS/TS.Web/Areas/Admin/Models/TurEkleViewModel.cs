using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class TurEkleViewModel
    {
        public int TurId { get; set; }
        [Required(ErrorMessage = "Tur alt kategori boş geçilemez")]
        public string TurAltKategori { get; set; }
        public string Anagrup { get; set; }
        public string ParaBirimi { get; set; }
        public string Vize { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi boş geçilemez")]
        [DataType(DataType.Date)]
        public DateTime BaslangicTarihi { get; set; }
    
        [Required(ErrorMessage = "Bitiş tarihi boş geçilemez")]
        [DataType(DataType.Date)]
        public DateTime BitisTarihi { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş geçilemez")]
        public double? Fiyat { get; set; }
        //[Required(ErrorMessage = "Resim alanı boş geçilemez")]
        public string Picture { get; set; }
        [Required(ErrorMessage = "Güzergah alanı boş geçilemez")]
        public string GidilecekYerler { get; set; }
        [Required(ErrorMessage = "Tur başlığı boş geçilemez")]
        public string TurBasligi { get; set; }
        [Required(ErrorMessage = "Fiyata dahil hizmetler alanı boş geçilemez")]
        public string FiyataDahilHizmetler { get; set; }
        [Required(ErrorMessage = "Fiyata dahil olmayan hizmetler alanı boş geçilemez")]
        public string FiyataDahilOlmayanHizmetler { get; set; }
        [Required(ErrorMessage = "Tur programı alanı boş geçilemez")]
        public string TurProgrami { get; set; }
        [Required(ErrorMessage = "Tur kalkış noktaları alanı boş geçilemez")]
        public string TurKalkisNoktalari { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public bool PopulerDurum { get; set; }
        [Required(ErrorMessage = "Ulaşım alanı boş geçilemez")]
        public string Ulasim { get; set; }
        [Required(ErrorMessage = "Resim alanı boş geçilemez")]
        public IFormFile ResimDosyasi { get; set; }
        public List<OtelBilgileri> OtelBilgileris { get; set; }
    }
}
