using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelAdminRezervasyonManager : IOtelAdminRezervasyonService
    {
        private readonly IOtelAdminRezervasyonDal _otelAdminRezervasyonDal;
        public OtelAdminRezervasyonManager(IOtelAdminRezervasyonDal otelAdminRezervasyonDal)
        {
            _otelAdminRezervasyonDal = otelAdminRezervasyonDal;
        }

        public List<OtelAdminRezervasyon> GetirHepsi()
        {
            return _otelAdminRezervasyonDal.GetirHepsi();
        }

        public OtelAdminRezervasyon GetirIdile(int id)
        {
            return _otelAdminRezervasyonDal.GetirIdile(id);
        }

        public List<OtelAdminRezervasyon> GetirTumTablolarla()
        {
            return _otelAdminRezervasyonDal.GetirTumTablolarla();
        }

        public void Guncelle(OtelAdminRezervasyon table)
        {
            _otelAdminRezervasyonDal.Guncelle(table);
        }

        public void Kaydet(OtelAdminRezervasyon table)
        {
            _otelAdminRezervasyonDal.Kaydet(table);
        }

        public void Sil(OtelAdminRezervasyon table)
        {
            _otelAdminRezervasyonDal.Sil(table);
        }
    }
}
