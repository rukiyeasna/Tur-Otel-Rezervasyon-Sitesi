using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class Slider : ITable
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Baslik { get; set; }
    }
}
