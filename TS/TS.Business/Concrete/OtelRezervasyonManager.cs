using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelRezervasyonManager : IOtelRezervasyonService
    {
        private readonly IOtelRezervasyonDal _otelRezervasyonDal;
        public OtelRezervasyonManager(IOtelRezervasyonDal otelRezervasyonDal)
        {
            _otelRezervasyonDal = otelRezervasyonDal;
        }
        public List<OtelRezervasyon> GetirHepsi()
        {
            return _otelRezervasyonDal.GetirHepsi();
        }

        public OtelRezervasyon GetirIdile(int id)
        {
            return _otelRezervasyonDal.GetirIdile(id);
        }

        public List<OtelRezervasyon> GetirTumTablolarla()
        {
            return _otelRezervasyonDal.GetirTumTablolarla();
        }

        public void Guncelle(OtelRezervasyon table)
        {
            _otelRezervasyonDal.Guncelle(table);
        }

        public void Kaydet(OtelRezervasyon table)
        {
            _otelRezervasyonDal.Kaydet(table);
        }

        public void Sil(OtelRezervasyon table)
        {
            _otelRezervasyonDal.Sil(table);
        }
    }
}
