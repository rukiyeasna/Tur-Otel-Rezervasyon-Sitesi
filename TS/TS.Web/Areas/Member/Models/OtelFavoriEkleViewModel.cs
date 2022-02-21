using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Member.Models
{
    public class OtelFavoriEkleViewModel
    {
        public int Id { get; set; }
        public Otel Otels { get; set; }
        public int OtelId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppUserId { get; set; }
    }
}
