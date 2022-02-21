using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelBilgileriManager : IOtelBilgileriService
    {
        private readonly IOtelBilgileriDal _otelBilgileriDal;
        public OtelBilgileriManager(IOtelBilgileriDal otelBilgileriDal)
        {
            _otelBilgileriDal = otelBilgileriDal;
        }
        public List<OtelBilgileri> GetirHepsi()
        {
            return _otelBilgileriDal.GetirHepsi();
        }

        public OtelBilgileri GetirIdile(int id)
        {
            return _otelBilgileriDal.GetirIdile(id);
        }

        public List<OtelBilgileri> GetirTumTablolarlaOtel()
        {
            return _otelBilgileriDal.GetirTumTablolarlaOtel();
        }

        public void Guncelle(OtelBilgileri table)
        {
            _otelBilgileriDal.Guncelle(table);
        }

        public void Kaydet(OtelBilgileri table)
        {
            _otelBilgileriDal.Kaydet(table);
        }

        public void Sil(OtelBilgileri table)
        {
            _otelBilgileriDal.Sil(table);
        }
    }
}
