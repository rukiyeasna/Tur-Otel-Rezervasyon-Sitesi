using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }
        public List<Slider> GetirHepsi()
        {
            return _sliderDal.GetirHepsi();
        }

        public Slider GetirIdile(int id)
        {
            return _sliderDal.GetirIdile(id);
        }

        public void Guncelle(Slider table)
        {
            _sliderDal.Guncelle(table);
        }

        public void Kaydet(Slider table)
        {
            _sliderDal.Kaydet(table);
        }

        public void Sil(Slider table)
        {
            _sliderDal.Sil(table);
        }
    }
}
