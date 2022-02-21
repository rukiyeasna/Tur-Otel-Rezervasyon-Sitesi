using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelOzellikManager : IOtelOzellikService
    {
        private readonly IOtelOzellikDal _otelOzellikDal;
        public OtelOzellikManager(IOtelOzellikDal otelOzellikDal)
        {
            _otelOzellikDal = otelOzellikDal;
        }
        public List<OtelOzellik> GetirHepsi()
        {
            return _otelOzellikDal.GetirHepsi();
        }

        public OtelOzellik GetirIdile(int id)
        {
            return _otelOzellikDal.GetirIdile(id);
        }

        public List<OtelOzellik> GetirOtelOzellikBilgileri()
        {
            return _otelOzellikDal.GetirOtelOzellikBilgileri();
        }

        public void Guncelle(OtelOzellik table)
        {
            _otelOzellikDal.Guncelle(table);
        }

        public void Kaydet(OtelOzellik table)
        {
            _otelOzellikDal.Kaydet(table);
        }

        public void Sil(OtelOzellik table)
        {
            _otelOzellikDal.Sil(table);
        }
    }
}
