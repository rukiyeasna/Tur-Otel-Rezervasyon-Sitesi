using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class ViewModel
    {
        public TurListViewModel TurListViewModel { get; set; }
        public OtelListViewModel OtelListViewModel { get; set; }
        public List<SliderViewModel> SliderViewModel { get; set; }
        public SliderAddViewModel SliderAddViewModel { get; set; }
        public List<SehirViewModel> SehirViewModel { get; set; }
    }
}
