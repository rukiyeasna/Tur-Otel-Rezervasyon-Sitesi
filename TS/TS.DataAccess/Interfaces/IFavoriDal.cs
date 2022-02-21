using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Interfaces
{
    public interface IFavoriDal : IGenericDal<Favori>
    {
        List<Favori> GetirTumTablolarla();
    }
}
