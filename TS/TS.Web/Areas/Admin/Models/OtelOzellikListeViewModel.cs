using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class OtelOzellikListeViewModel
    {
        public int Id { get; set; }
        public string Ozellik { get; set; }
        public int OtelId { get; set; }
    }
}
