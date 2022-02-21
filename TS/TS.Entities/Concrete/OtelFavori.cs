using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class OtelFavori : ITable
    {
        public int Id { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppUserId { get; set; }
    }
}
