using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Interfaces
{
    public interface IOtelBilgileriDal : IGenericDal<OtelBilgileri>
    {
        //List<OtelBilgileri> GetirTumTablolarla();
        List<OtelBilgileri> GetirTumTablolarlaOtel();
    }
}
