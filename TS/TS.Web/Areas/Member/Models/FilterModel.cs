using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.Areas.Member.Models
{
    public class FilterModel
    {
        public string anagrup { get; set; }
        public string altkategori { get; set; }
        public string ulasimturu { get; set; }
        public double? altfiyat { get; set; }
        public double? ustfiyat { get; set; }

    }
}
