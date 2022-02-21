﻿using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.Business.Interfaces
{
    public interface IOtelBilgileriService : IGenericService<OtelBilgileri>
    {
        List<OtelBilgileri> GetirTumTablolarlaOtel();
    }
}
