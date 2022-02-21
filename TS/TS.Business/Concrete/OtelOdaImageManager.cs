using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class OtelOdaImageManager : IOtelOdaImageService
    {
        private readonly IOtelOdaImageDal _otelOdaImageDal;
        public OtelOdaImageManager(IOtelOdaImageDal otelOdaImageDal)
        {
            _otelOdaImageDal = otelOdaImageDal;
        }
        public List<OtelOdaImage> GetirHepsi()
        {
            return _otelOdaImageDal.GetirHepsi();
        }

        public OtelOdaImage GetirIdile(int id)
        {
            return _otelOdaImageDal.GetirIdile(id);
        }

        public void Guncelle(OtelOdaImage table)
        {
            _otelOdaImageDal.Guncelle(table);
        }

        public void Kaydet(OtelOdaImage table)
        {
            _otelOdaImageDal.Kaydet(table);
        }

        public void Sil(OtelOdaImage table)
        {
            _otelOdaImageDal.Sil(table);
        }
    }
}
