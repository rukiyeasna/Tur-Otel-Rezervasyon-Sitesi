using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Models
{
    public class OtelOdaImageListViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int OtelOdaId { get; set; }
        public OtelOda OtelOdas { get; set; }
    }
}
