using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Models
{
    public class ImagesAdminViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int TurId { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
    }
}
