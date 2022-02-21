using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelFavoriManager : IOtelFavoriService
    {
        private readonly IOtelFavoriDal _otelFavoriDal;
        public OtelFavoriManager(IOtelFavoriDal otelFavoriDal)
        {
            _otelFavoriDal = otelFavoriDal;
        }

        public List<OtelFavori> GetirHepsi()
        {
            return _otelFavoriDal.GetirHepsi();
        }

        public OtelFavori GetirIdile(int id)
        {
            return _otelFavoriDal.GetirIdile(id);
        }

        public List<OtelFavori> GetirTumTablolarla()
        {
            return _otelFavoriDal.GetirTumTablolarla();
        }

        public void Guncelle(OtelFavori table)
        {
            _otelFavoriDal.Guncelle(table);
        }

        public void Kaydet(OtelFavori table)
        {
            _otelFavoriDal.Kaydet(table);
        }

        public void Sil(OtelFavori table)
        {
            _otelFavoriDal.Sil(table);
        }
    }
}
