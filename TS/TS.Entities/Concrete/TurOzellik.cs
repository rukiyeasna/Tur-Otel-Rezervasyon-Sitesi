using System;
using System.Collections.Generic;
using System.Text;

namespace TS.Entities.Concrete
{
    public class TurOzellik
    {
        public int Id { get; set; }
        public string Ozellik { get; set; }
        public int TurId { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
    }
}
