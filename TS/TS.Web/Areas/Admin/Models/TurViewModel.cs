using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class TurViewModel
    {
        public int TurId { get; set; }
        public string TurBasligi { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
    }
}
