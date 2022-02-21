using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Interfaces
{
    public interface IOtelOdaDal : IGenericDal<OtelOda>
    {
        List<OtelOda> GetirOtelBilgileri();
    }
}
