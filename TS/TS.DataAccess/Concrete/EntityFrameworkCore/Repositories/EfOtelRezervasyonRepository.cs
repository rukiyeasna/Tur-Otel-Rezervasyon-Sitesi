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
    public class EfOtelRezervasyonRepository : EfGenericRepository<OtelRezervasyon>, IOtelRezervasyonDal
    {
        public List<OtelRezervasyon> GetirTumTablolarla()
        {
            using var context = new TsContext();
            return context.OtelRezervasyon.Include(I => I.Otels).Include(I => I.AppUsers).Include(I => I.OtelOdas).ToList();
        }
    }
}
