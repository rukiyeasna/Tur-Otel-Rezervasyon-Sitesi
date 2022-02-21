using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Interfaces
{
    public interface IOtelAdminRezervasyonDal : IGenericDal<OtelAdminRezervasyon>
    {
        List<OtelAdminRezervasyon> GetirTumTablolarla();
    }
}
