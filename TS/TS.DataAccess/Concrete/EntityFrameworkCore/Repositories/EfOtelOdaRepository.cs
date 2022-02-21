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
    public class EfOtelOdaRepository : EfGenericRepository<OtelOda>, IOtelOdaDal
    {
        public List<OtelOda> GetirOtelBilgileri()
        {
            using var context = new TsContext();
            return context.OtelOda.Include(I => I.Otels).ToList();
        }
    }
}
