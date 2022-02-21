using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfOtelBilgileriRepository : EfGenericRepository<OtelBilgileri>, IOtelBilgileriDal
    {
        public List<OtelBilgileri> GetirTumTablolarlaOtel()
        {
            using var context = new TsContext();
            return context.OtelBilgileri.Include(I => I.TurBilgileris).ToList();
        }
    }
}
