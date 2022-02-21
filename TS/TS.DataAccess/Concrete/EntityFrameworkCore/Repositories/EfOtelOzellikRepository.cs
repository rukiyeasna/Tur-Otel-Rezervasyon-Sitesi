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
    public class EfOtelOzellikRepository : EfGenericRepository<OtelOzellik>, IOtelOzellikDal
    {
        public List<OtelOzellik> GetirOtelOzellikBilgileri()
        {
            using var context = new TsContext();
            return context.OtelOzellik.Include(I => I.Otels).ToList();
        }
    }
}
