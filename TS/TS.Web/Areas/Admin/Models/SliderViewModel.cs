using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Admin.Models
{
    public class SliderViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Baslik { get; set; }       
    }
}
