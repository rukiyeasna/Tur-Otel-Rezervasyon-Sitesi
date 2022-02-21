using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelPuanManager : IOtelPuanService
    {
        private readonly IOtelPuanDal _otelPuanDal;
        public OtelPuanManager(IOtelPuanDal otelPuanDal)
        {
            _otelPuanDal = otelPuanDal;
        }
        public List<OtelPuan> GetirHepsi()
        {
            return _otelPuanDal.GetirHepsi();
        }

        public OtelPuan GetirIdile(int id)
        {
            return _otelPuanDal.GetirIdile(id);
        }

        public void Guncelle(OtelPuan table)
        {
            _otelPuanDal.Guncelle(table);
        }

        public void Kaydet(OtelPuan table)
        {
            _otelPuanDal.Kaydet(table);
        }

        public void Sil(OtelPuan table)
        {
            _otelPuanDal.Sil(table);
        }
    }
}
