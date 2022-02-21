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
    public class EfOtelAdminRezervasyonRepository : EfGenericRepository<OtelAdminRezervasyon>, IOtelAdminRezervasyonDal
    {
        public List<OtelAdminRezervasyon> GetirTumTablolarla()
        {
            using var context = new TsContext();
            return context.OtelAdminRezervasyon.Include(I => I.Otels).Include(I => I.OtelOdas).ToList();
        }
    }
}
