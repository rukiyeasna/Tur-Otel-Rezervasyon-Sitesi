using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelImageManager : IOtelImageService
    {
        private readonly IOtelImageDal _otelImageDal;
        public OtelImageManager(IOtelImageDal otelImageDal)
        {
            _otelImageDal = otelImageDal;
        }
        public List<OtelImage> GetirHepsi()
        {
            return _otelImageDal.GetirHepsi();
        }

        public OtelImage GetirIdile(int id)
        {
            return _otelImageDal.GetirIdile(id);
        }

        public void Guncelle(OtelImage table)
        {
            _otelImageDal.Guncelle(table);
        }

        public void Kaydet(OtelImage table)
        {
            _otelImageDal.Kaydet(table);
        }

        public void Sil(OtelImage table)
        {
            _otelImageDal.Sil(table);
        }
    }
}
