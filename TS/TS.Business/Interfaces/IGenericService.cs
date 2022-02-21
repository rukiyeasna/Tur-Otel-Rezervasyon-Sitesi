using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Interfaces;

namespace TS.Business.Interfaces
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        void Kaydet(Table table);
        void Sil(Table table);
        void Guncelle(Table table);
        Table GetirIdile(int id);
        List<Table> GetirHepsi();
    }
}
