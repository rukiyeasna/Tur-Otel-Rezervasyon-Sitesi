using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class Favori : ITable
    {
        public int Id { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        public int TurId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppUserId { get; set; }

    }
}
