using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Web.Models;

namespace TS.Web.Areas.Admin.Models
{
    public class ViewOrtakModel
    {
        public List<SliderListViewModel> SliderListViewModel { get; set; }
        public List<TurListViewModel> TurListViewModel { get; set; }
        public List<TurListViewModel> TurlarListViewModel { get; set; }
        public List<TurListViewModel> TurBilgileriViewModel { get; set; }
        public AramaViewModel AramaViewModel { get; set; }
     
    }
}
