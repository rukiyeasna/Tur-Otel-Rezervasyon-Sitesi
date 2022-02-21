using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class MesajMemberViewModel
    {
        public int Id { get; set; }
        public string Alici { get; set; }
        public string Gonderici { get; set; }
        public string Kategori { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
    }
}
