using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Models;

namespace TS.Web.Controllers
{
    public class TurAltKategoriController : Controller
    {
        private readonly ITurBilgileriService _turBilgileriService;
        public TurAltKategoriController(ITurBilgileriService turBilgileriService)
        {
            _turBilgileriService = turBilgileriService;
        }
        public IActionResult Index(string altKategori, DateTime b)
        {
            List<TurBilgileri> turBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.TurAltKategori == altKategori).Where(y => y.Durum == true).ToList();
            List<TurListViewModel> modeltur = new List<TurListViewModel>();

            foreach (var item in turBilgileri)
            {
                TurListViewModel turmodel = new TurListViewModel();
                turmodel.TurId = item.TurId;
                turmodel.TurBasligi = item.TurBasligi;
                turmodel.BaslangicTarihi = item.BaslangicTarihi;
                turmodel.BitisTarihi = item.BitisTarihi;
                turmodel.Picture = item.Picture;
                turmodel.Fiyat = item.Fiyat;
                modeltur.Add(turmodel);
            }
            ViewBag.TurAltBaslik = altKategori;
            return View(modeltur);


        }      
    }
}
