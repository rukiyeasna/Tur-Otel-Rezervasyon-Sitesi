using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TS.DataAccess.Interfaces;
using TS.Entities.Interfaces;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table>
        where Table : class, ITable, new()
    {
        public List<Table> GetirHepsi()
        {

            using var context = new TsContext();
            return context.Set<Table>().ToList();
        }

        public Table GetirIdile(int id)
        {
            using var context = new TsContext();
            return context.Set<Table>().Find(id);
        }

        public void Guncelle(Table table)
        {
            using var context = new TsContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }

        public void Kaydet(Table table)
        {
            using var context = new TsContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Sil(Table table)
        {
            using var context = new TsContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }
    }
}
