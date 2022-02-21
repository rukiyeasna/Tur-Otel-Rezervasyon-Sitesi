using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelOdaOzellikManager : IOtelOdaOzellikService
    {
        private readonly IOtelOdaOzellikDal _otelodaOzellikDal;
        public OtelOdaOzellikManager(IOtelOdaOzellikDal otelodaOzellikDal)
        {
            _otelodaOzellikDal = otelodaOzellikDal;
        }
        public List<OtelOdaOzellik> GetirHepsi()
        {
            return _otelodaOzellikDal.GetirHepsi();
        }

        public OtelOdaOzellik GetirIdile(int id)
        {
            return _otelodaOzellikDal.GetirIdile(id);
        }

        public void Guncelle(OtelOdaOzellik table)
        {
            _otelodaOzellikDal.Guncelle(table);
        }

        public void Kaydet(OtelOdaOzellik table)
        {
            _otelodaOzellikDal.Kaydet(table);
        }

        public void Sil(OtelOdaOzellik table)
        {
            _otelodaOzellikDal.Sil(table);
        }
    }
}
