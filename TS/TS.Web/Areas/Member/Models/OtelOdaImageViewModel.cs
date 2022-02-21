using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Member.Models
{
    public class OtelOdaImageViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int OtelOdaId { get; set; }
        public OtelOda OtelOdas { get; set; }
    }
}
