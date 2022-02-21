using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class RezervasyonManager : IRezervasyonService
    {
        private readonly IRezervasyonDal _rezervasyonDal;

        public RezervasyonManager(IRezervasyonDal rezervasyonDal)
        {
            _rezervasyonDal = rezervasyonDal;
        }

        public List<Rezervasyon> GetirHepsi()
        {
            return _rezervasyonDal.GetirHepsi();
        }

        public Rezervasyon GetirIdile(int id)
        {
            return _rezervasyonDal.GetirIdile(id);
        }

        public List<Rezervasyon> GetirTumTablolarla()
        {
            return _rezervasyonDal.GetirTumTablolarla();
        }

        public void Guncelle(Rezervasyon table)
        {
            _rezervasyonDal.Guncelle(table);
        }

        public void Kaydet(Rezervasyon table)
        {
            _rezervasyonDal.Kaydet(table);
        }

        public void Sil(Rezervasyon table)
        {
            _rezervasyonDal.Sil(table);
        }
    }
}
