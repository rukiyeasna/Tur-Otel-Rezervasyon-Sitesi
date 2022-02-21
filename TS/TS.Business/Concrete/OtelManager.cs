using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelManager : IOtelService
    {
        private readonly IOtelDal _otelDal;
        public OtelManager(IOtelDal otelDal)
        {
            _otelDal = otelDal;
        }
        public List<Otel> GetirHepsi()
        {
            return _otelDal.GetirHepsi();
        }

        public Otel GetirIdile(int id)
        {
            return _otelDal.GetirIdile(id);
        }

        public void Guncelle(Otel table)
        {
            _otelDal.Guncelle(table);
        }

        public void Kaydet(Otel table)
        {
            _otelDal.Kaydet(table);
        }

        public void Sil(Otel table)
        {
            _otelDal.Sil(table);
        }
    }
}
