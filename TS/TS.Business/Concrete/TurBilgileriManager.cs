using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class TurBilgileriManager : ITurBilgileriService
    {
        private readonly ITurBilgileriDal _turBilgileriDal;
        public TurBilgileriManager(ITurBilgileriDal turBilgileriDal)
        {
            _turBilgileriDal = turBilgileriDal;
        }

        public List<TurBilgileri> GetirHepsi()
        {
            return _turBilgileriDal.GetirHepsi();
        }

        public TurBilgileri GetirIdile(int id)
        {
            return _turBilgileriDal.GetirIdile(id);
        }

        public void Guncelle(TurBilgileri table)
        {
            _turBilgileriDal.Guncelle(table);
        }

        public void Kaydet(TurBilgileri table)
        {
            _turBilgileriDal.Kaydet(table);
        }

        public void Sil(TurBilgileri table)
        {
            _turBilgileriDal.Sil(table);
        }
    }
}
