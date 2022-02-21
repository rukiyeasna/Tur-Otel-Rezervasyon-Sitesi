using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.Business.Interfaces
{
    public interface IOtelFavoriService : IGenericService<OtelFavori>
    {
        public List<OtelFavori> GetirTumTablolarla();
    }
}
