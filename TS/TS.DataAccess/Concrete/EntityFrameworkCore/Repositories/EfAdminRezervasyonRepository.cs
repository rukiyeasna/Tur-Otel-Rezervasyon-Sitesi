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
    public class EfAdminRezervasyonRepository : EfGenericRepository<AdminRezervasyon>, IAdminRezervasyonDal
    {
        public List<AdminRezervasyon> GetirTumTablolarla()
        {
            using var context = new TsContext();
            return context.AdminRezervasyon.Include(I => I.TurBilgileris).Include(I => I.OtelBilgileris).ToList();
        }
    }
}
