using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class MesajManager : IMesajService
    {
        private readonly IMesajDal _mesajDal;
        public MesajManager(IMesajDal mesajDal)
        {
            _mesajDal = mesajDal;
        }
        public List<Mesaj> GetirHepsi()
        {
            return _mesajDal.GetirHepsi();
        }

        public Mesaj GetirIdile(int id)
        {
            return _mesajDal.GetirIdile(id);
        }

        public void Guncelle(Mesaj table)
        {
            _mesajDal.Guncelle(table);
        }

        public void Kaydet(Mesaj table)
        {
            _mesajDal.Kaydet(table);
        }

        public void Sil(Mesaj table)
        {
            _mesajDal.Sil(table);
        }
    }
}
