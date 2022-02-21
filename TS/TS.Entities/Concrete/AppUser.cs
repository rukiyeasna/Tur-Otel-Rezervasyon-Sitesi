using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
        public List<Favori> Favoris { get; set; }
        public List<OtelFavori> OtelFavoris { get; set; }
        public List<Rezervasyon> Rezervasyons { get; set; }
        public List<OtelRezervasyon> OtelRezervasyons { get; set; }
    }
}
