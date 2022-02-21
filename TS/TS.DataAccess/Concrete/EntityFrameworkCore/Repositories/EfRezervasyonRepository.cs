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
    public class EfRezervasyonRepository : EfGenericRepository<Rezervasyon>, IRezervasyonDal
    {
        public List<Rezervasyon> GetirTumTablolarla()
        {
            using var context = new TsContext();
            return context.Rezervasyon.Include(I => I.TurBilgileris).Include(I => I.AppUsers).Include(I => I.OtelBilgileris).ToList();
        }
    }
}
