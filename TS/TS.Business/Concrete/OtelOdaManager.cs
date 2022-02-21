using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelOdaManager : IOtelOdaService
    {
        private readonly IOtelOdaDal _otelOdaDal;
        public OtelOdaManager(IOtelOdaDal otelOdaDal)
        {
            _otelOdaDal = otelOdaDal;
        }
        public List<OtelOda> GetirHepsi()
        {
            return _otelOdaDal.GetirHepsi();
        }

        public OtelOda GetirIdile(int id)
        {
            return _otelOdaDal.GetirIdile(id);
        }

        public List<OtelOda> GetirOtelBilgileri()
        {
            return _otelOdaDal.GetirOtelBilgileri();
        }

        public void Guncelle(OtelOda table)
        {
            _otelOdaDal.Guncelle(table);
        }

        public void Kaydet(OtelOda table)
        {
            _otelOdaDal.Kaydet(table);
        }

        public void Sil(OtelOda table)
        {
            _otelOdaDal.Sil(table);
        }
    }
}
