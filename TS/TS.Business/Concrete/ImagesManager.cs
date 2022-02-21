using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class ImagesManager : IImagesService
    {
        private readonly IImagesDal _imagesDal;
        public ImagesManager(IImagesDal imagesDal)
        {
            _imagesDal = imagesDal;
        }

        public List<Images> GetirHepsi()
        {
            return _imagesDal.GetirHepsi();
        }

        public Images GetirIdile(int id)
        {
            return _imagesDal.GetirIdile(id);
        }

        public void Guncelle(Images table)
        {
            _imagesDal.Guncelle(table);
        }

        public void Kaydet(Images table)
        {
            _imagesDal.Kaydet(table);
        }

        public void Sil(Images table)
        {
            _imagesDal.Sil(table);
        }
    }
}
