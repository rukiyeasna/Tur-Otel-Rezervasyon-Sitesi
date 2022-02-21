using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;

using TS.Web.Models;

namespace TS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly IOtelBilgileriService _otelBilgileriService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IImagesService _imagesService;
        public HomeController(ISliderService sliderService, ITurBilgileriService turBilgileriService, IOtelBilgileriService otelBilgileriService, UserManager<AppUser> userManager, IImagesService imagesService)
        {
            _sliderService = sliderService;
            _turBilgileriService = turBilgileriService;
            _otelBilgileriService = otelBilgileriService;
            _userManager = userManager;
            _imagesService = imagesService;
        }
        public IActionResult Index()
        {

            ViewOrtakModel viewModel = new ViewOrtakModel();
            List<Slider> slider = _sliderService.GetirHepsi().ToList();
            List<SliderListViewModel> model = new List<SliderListViewModel>();
            foreach (var item in slider)
            {
                SliderListViewModel slidermodel = new SliderListViewModel();
                slidermodel.Id = item.Id;
                slidermodel.Baslik = item.Baslik;
                slidermodel.Picture = item.Picture;
                model.Add(slidermodel);
            }

            List<TurBilgileri> turBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.PopulerDurum == true).Where(y => y.Durum == true).ToList();
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


            List<TurBilgileri> TurBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).ToList();
            List<TurListViewModel> Modeltur = new List<TurListViewModel>();
            foreach (var item in TurBilgileri)
            {
                TurListViewModel Turmodel = new TurListViewModel();
                Turmodel.TurId = item.TurId;
                Turmodel.TurBasligi = item.TurBasligi;
                Turmodel.BaslangicTarihi = item.BaslangicTarihi;
                Turmodel.BitisTarihi = item.BitisTarihi;
                Turmodel.Picture = item.Picture;
                Turmodel.Fiyat = item.Fiyat;
                Modeltur.Add(Turmodel);
            }


            viewModel.TurlarListViewModel = Modeltur;
            viewModel.SliderListViewModel = model;
            viewModel.TurListViewModel = modeltur;
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Arama(string kategori, DateTime baslangic, DateTime bitis)
        {
            ViewBag.baslangic = baslangic;
            ViewBag.bitis = bitis;
            ViewBag.kategori = kategori;

            List<TurBilgileri> TurBilgileri;
            List<TurListViewModel> Modeltur = new List<TurListViewModel>();

            if (kategori != "null" && baslangic != null && bitis != null)
            {
                TurBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.BaslangicTarihi >= baslangic).Where(x => x.BitisTarihi <= bitis).Where(x => x.TurAltKategori == kategori).Where(x => x.Durum == true).ToList();
                foreach (var item in TurBilgileri)
                {
                    TurListViewModel Turmodel = new TurListViewModel();
                    Turmodel.TurId = item.TurId;
                    Turmodel.TurBasligi = item.TurBasligi;
                    Turmodel.BaslangicTarihi = item.BaslangicTarihi;
                    Turmodel.BitisTarihi = item.BitisTarihi;
                    Turmodel.Picture = item.Picture;
                    Turmodel.Fiyat = item.Fiyat;
                    Modeltur.Add(Turmodel);
                }
                ViewBag.sayi = TurBilgileri.Count();
                //return View(Modeltur);
            }

            else if (kategori == "null" && baslangic != null && bitis != null)
            {
                TurBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.BaslangicTarihi >= baslangic).Where(x => x.BitisTarihi <= bitis).Where(x => x.Durum == true).ToList();
                foreach (var item in TurBilgileri)
                {
                    TurListViewModel Turmodel = new TurListViewModel();
                    Turmodel.TurId = item.TurId;
                    Turmodel.TurBasligi = item.TurBasligi;
                    Turmodel.BaslangicTarihi = item.BaslangicTarihi;
                    Turmodel.BitisTarihi = item.BitisTarihi;
                    Turmodel.Picture = item.Picture;
                    Turmodel.Fiyat = item.Fiyat;
                    Modeltur.Add(Turmodel);
                }
                ViewBag.sayi = TurBilgileri.Count();
            }           
            return View(Modeltur);

        }

        public IActionResult TurBilgileri(int id)
        {
            ViewOrtakModel viewOrtak = new ViewOrtakModel();
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
                Durum = true,
                PopulerDurum = tur.PopulerDurum,
                Picture = tur.Picture,
                Ulasim = tur.Ulasim

            };

            List<Images> images = _imagesService.GetirHepsi().Where(x => x.TurId == id).ToList();
            List<ImagesViewModel> imageModel = new List<ImagesViewModel>();
            foreach (var item in images)
            {
                ImagesViewModel imagesViewModel = new ImagesViewModel();
                imagesViewModel.Id = item.Id;
                imagesViewModel.TurId = item.TurId;
                imagesViewModel.Picture = item.Picture;
                imageModel.Add(imagesViewModel);

            }

            ViewBag.Image = imageModel;
            ViewBag.sayi = images.Count();

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirHepsi().Where(x => x.TurId == id).ToList();
            List<OtelBilgiViewModel> ModelOtel = new List<OtelBilgiViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelBilgiViewModel Otelmodel = new OtelBilgiViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                ModelOtel.Add(Otelmodel);
            }
            ViewBag.Otel = ModelOtel;
            return View(model);
        }

        public IActionResult Favori()
        {
            return View();
        }

    }
}
