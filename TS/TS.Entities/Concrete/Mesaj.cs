using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class Mesaj : ITable
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
