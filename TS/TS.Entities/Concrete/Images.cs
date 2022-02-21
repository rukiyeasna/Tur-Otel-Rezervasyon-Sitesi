using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class Images : ITable
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int TurId { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
    }
}
