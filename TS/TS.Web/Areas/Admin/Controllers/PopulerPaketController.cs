using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Areas.Admin.Models;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PopulerPaketController : Controller
    {
        private readonly ITurBilgileriService _turBilgileriService;
        public PopulerPaketController(ITurBilgileriService turBilgileriService)
        {
            _turBilgileriService = turBilgileriService;
        }
        public IActionResult Index()
        {
            List<TurBilgileri> populer = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).Where(y => y.PopulerDurum == true).ToList();
            List<TurListViewModel> modelpop = new List<TurListViewModel>();
            foreach (var item in populer)
            {
                TurListViewModel turModelpop = new TurListViewModel();
                turModelpop.TurId = item.TurId;
                turModelpop.BaslangicTarihi = item.BaslangicTarihi;
                turModelpop.BitisTarihi = item.BitisTarihi;
                turModelpop.TurBasligi = item.TurBasligi;
                turModelpop.Picture = item.Picture;
                modelpop.Add(turModelpop);
            }
            ViewBag.a = modelpop;

            List<TurBilgileri> tur = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).Where(y => y.PopulerDurum == false).ToList();
            List<TurListViewModel> model = new List<TurListViewModel>();
            foreach (var item in tur)
            {
                TurListViewModel turModel = new TurListViewModel();
                turModel.TurId = item.TurId;
                turModel.BaslangicTarihi = item.BaslangicTarihi;
                turModel.BitisTarihi = item.BitisTarihi;
                turModel.TurBasligi = item.TurBasligi;
                turModel.GidilecekYerler = item.GidilecekYerler;
                turModel.Picture = item.Picture;
                turModel.TurAltKategori = item.TurAltKategori;
                model.Add(turModel);
            }
            return View(model);


        }

        public IActionResult DetaylarSil(int id)
        {
            var tur = _turBilgileriService.GetirIdile(id);
            TurListViewModel model = new TurListViewModel
            {
                TurId = tur.TurId,
                TurAltKategori = tur.TurAltKategori,
                BaslangicTarihi = tur.BaslangicTarihi,
                BitisTarihi = tur.BitisTarihi,
                Fiyat = tur.Fiyat,
                GidilecekYerler = tur.GidilecekYerler,
                TurBasligi = tur.TurBasligi,
                FiyataDahilHizmetler = tur.FiyataDahilHizmetler,
                FiyataDahilOlmayanHizmetler = tur.FiyataDahilOlmayanHizmetler,
                TurProgrami = tur.TurProgrami,
                TurKalkisNoktalari = tur.TurKalkisNoktalari,
                Aciklama = tur.Aciklama,
                Durum = tur.Durum,
                PopulerDurum = tur.PopulerDurum,
                Picture = tur.Picture,
                Ulasim = tur.Ulasim

            };
            return View(model);
        }

        public IActionResult TurKaldir(int id)
        {
            var getir = _turBilgileriService.GetirIdile(id);
            getir.PopulerDurum = false;
            _turBilgileriService.Guncelle(getir);
            return RedirectToAction("Index");
        }

        //public IActionResult PopEkle()
        //{
        //    //List<TurBilgileri> tur = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).Where(y => y.PopulerDurum == false).ToList();
        //    //List<TurListViewModel> model = new List<TurListViewModel>();


        //    //foreach (var item in tur)
        //    //{
        //    //    TurListViewModel turModel = new TurListViewModel();
        //    //    turModel.TurId = item.TurId;
        //    //    turModel.BaslangicTarihi = item.BaslangicTarihi;
        //    //    turModel.BitisTarihi = item.BitisTarihi;
        //    //    turModel.TurBasligi = item.TurBasligi;
        //    //    turModel.TurAltKategori = item.TurAltKategori;
        //    //    turModel.Picture = item.Picture;
        //    //    model.Add(turModel);
        //    //}
        //    //ViewBag.a = model;
        //    //return View();
        //    List<TurBilgileri> tur = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).Where(y=>y.PopulerDurum==false).ToList();
        //    List<TurListViewModel> model = new List<TurListViewModel>();
        //    foreach (var item in tur)
        //    {
        //        TurListViewModel turModel = new TurListViewModel();
        //        turModel.TurId = item.TurId;
        //        turModel.BaslangicTarihi = item.BaslangicTarihi;
        //        turModel.BitisTarihi = item.BitisTarihi;
        //        turModel.TurBasligi = item.TurBasligi;
        //        turModel.GidilecekYerler = item.GidilecekYerler;
        //        turModel.Picture = item.Picture;
        //        model.Add(turModel);
        //    }
        //    return View(model);
        //}


        public IActionResult PopEkleme(int id)
        {           
            var getir = _turBilgileriService.GetirIdile(id);
            getir.PopulerDurum = true;
            _turBilgileriService.Guncelle(getir);
            return RedirectToAction("Index");
        }

        public IActionResult Kaldir(int id)
        {
            var getir = _turBilgileriService.GetirIdile(id);
            getir.PopulerDurum = false;
            _turBilgileriService.Guncelle(getir);
            return RedirectToAction("Index");
        }
    }
}
