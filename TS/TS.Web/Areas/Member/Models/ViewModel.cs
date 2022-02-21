using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class ViewModel
    {
        public List<OtelViewModel> otelViewModels { get; set; }
        public List<RezervasyonViewModel> rezervasyonViewModels { get; set; }
        public List<FilterModel> filterModels { get; set; }
    }
}
