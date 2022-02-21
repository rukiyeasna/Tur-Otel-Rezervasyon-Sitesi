using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class OtelOzellik : ITable
    {
        public int Id { get; set; }
        public string Ozellik { get; set; }
        public int OtelId { get; set; }
        public Otel Otels { get; set; }
    }
}
