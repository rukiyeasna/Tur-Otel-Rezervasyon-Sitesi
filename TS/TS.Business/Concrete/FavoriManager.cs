using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class FavoriManager : IFavoriService
    {
        private readonly IFavoriDal _favoriDal;
        public FavoriManager(IFavoriDal favoriDal)
        {
            _favoriDal = favoriDal;
        }

        public List<Favori> GetirHepsi()
        {
            return _favoriDal.GetirHepsi();
        }

        public Favori GetirIdile(int id)
        {
            return _favoriDal.GetirIdile(id);
        }

        public List<Favori> GetirTumTablolarla()
        {
            return _favoriDal.GetirTumTablolarla();
        }

        public void Guncelle(Favori table)
        {
            _favoriDal.Guncelle(table);
        }

        public void Kaydet(Favori table)
        {
            _favoriDal.Kaydet(table);
        }

        public void Sil(Favori table)
        {
            _favoriDal.Sil(table);
        }
    }
}
