using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class OtelOdaOzellik : ITable
    {
        public int Id { get; set; }
        public string Ozellik { get; set; }
        public int OtelOdaId { get; set; }
        public OtelOda OtelOdas { get; set; }
    }
}
