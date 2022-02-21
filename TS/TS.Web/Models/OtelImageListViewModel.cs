using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Models
{
    public class OtelImageListViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int OtelId { get; set; }
        public Otel Otels { get; set; }
    }
}
