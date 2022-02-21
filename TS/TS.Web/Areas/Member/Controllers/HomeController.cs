using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Web.Models;
using TS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using TS.Web.Areas.Member.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TS.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IOtelBilgileriService _otelBilgileriService;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFavoriService _favoriService;
        private readonly IImagesService _imagesService;
        private readonly IOtelFavoriService _otelFavoriService;
        public HomeController(IOtelFavoriService otelFavoriService, ITurBilgileriService turBilgileriService, IOtelBilgileriService otelBilgileriService, UserManager<AppUser> userManager, IFavoriService favoriService, IImagesService imagesService)
        {
            _otelBilgileriService = otelBilgileriService;
            _turBilgileriService = turBilgileriService;
            _userManager = userManager;
            _favoriService = favoriService;
            _imagesService = imagesService;
            _otelFavoriService = otelFavoriService;
        }
        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullaniciId = appUser.Id;

            ViewOrtakModel viewModel = new ViewOrtakModel();
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
                turmodel.ParaBirimi = item.ParaBirimi;
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
                Turmodel.ParaBirimi = item.ParaBirimi;
                Modeltur.Add(Turmodel);
            }


            viewModel.TurlarListViewModel = Modeltur;

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
                    Turmodel.ParaBirimi = item.ParaBirimi;
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
                    Turmodel.ParaBirimi = item.ParaBirimi;
                    Modeltur.Add(Turmodel);
                }
                ViewBag.sayi = TurBilgileri.Count();
            }
            return View(Modeltur);

        }

        public async Task<IActionResult> TurBilgileri(int id)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullaniciId = appUser.Id;

            ViewBag.Tur = new SelectList(_otelBilgileriService.GetirHepsi().Where(x => x.TurId == id), "OtelBilgiId", "FiyatTanimi");

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
                Ulasim = tur.Ulasim,
                Anagrup = tur.Anagrup,
                Vize = tur.Vize,
                ParaBirimi = tur.ParaBirimi,


            };

            ViewBag.TurId = tur.TurId;

            List<Images> images = _imagesService.GetirHepsi().Where(x => x.TurId == id).ToList();
            List<ImagesMemberViewModel> imageModel = new List<ImagesMemberViewModel>();
            foreach (var item in images)
            {
                ImagesMemberViewModel imagesViewModel = new ImagesMemberViewModel();
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

        public IActionResult Favori(int userId, int turId)
        {
            List<Favori> favori = _favoriService.GetirHepsi().Where(x => x.AppUserId == userId).ToList();
            FavoriListViewModel favoriListViewModel = new FavoriListViewModel();
            foreach (var item in favori)
            {
                //favoriListViewModel.AppUserId = item.AppUserId;
                //favoriListViewModel.TurId = item.TurId;
                if (item.TurId == turId)
                {
                    return RedirectToAction("Favorilerim");
                }

            }

            FavoriEkleViewModel model = new FavoriEkleViewModel();
            if (ModelState.IsValid)
            {
                _favoriService.Kaydet(new Favori
                {
                    Id = model.Id,
                    AppUserId = userId,
                    TurId = turId
                });

                return RedirectToAction("Favorilerim");
            }
            return View();
        }

        public async Task<IActionResult> Favorilerim()
        {
            //var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            //var kullaniciId = appUser.Id;
            //List<Favori> favori = _favoriService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).ToList();
            //return View(favori);

            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<Favori> favori = _favoriService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).ToList();
            ViewBag.FavoriTur = favori;

            List<OtelFavori> otelfavori = _otelFavoriService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).ToList();
            //ViewBag.FavoriOtel = otelfavori;

            return View(otelfavori);
        }

        public IActionResult FavoriKaldır(int id)
        {
            _favoriService.Sil(new Favori { Id = id });
            return RedirectToAction("Favorilerim");
        }

        public IActionResult Filter(string anagrup, string altkategori, string ulasimturu/*, double? altfiyat, double? ustfiyat*/)
        {
            List<TurBilgileri> TurBilgileri;
            List<TurListViewModel> Modeltur = new List<TurListViewModel>();

            if (anagrup != null)
            {
                TurBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.Anagrup == anagrup).Where(x => x.Durum == true).ToList();
                foreach (var item in TurBilgileri)
                {
                    TurListViewModel Turmodel = new TurListViewModel();
                    Turmodel.TurId = item.TurId;
                    Turmodel.TurBasligi = item.TurBasligi;
                    Turmodel.BaslangicTarihi = item.BaslangicTarihi;
                    Turmodel.BitisTarihi = item.BitisTarihi;
                    Turmodel.Picture = item.Picture;
                    Turmodel.Fiyat = item.Fiyat;
                    Turmodel.ParaBirimi = item.ParaBirimi;
                    Modeltur.Add(Turmodel);
                }
                ViewBag.Baslik = anagrup;
            }
            else if (altkategori != null)
            {
                TurBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.TurAltKategori == altkategori).Where(x => x.Durum == true).ToList();
                foreach (var item in TurBilgileri)
                {
                    TurListViewModel Turmodel = new TurListViewModel();
                    Turmodel.TurId = item.TurId;
                    Turmodel.TurBasligi = item.TurBasligi;
                    Turmodel.BaslangicTarihi = item.BaslangicTarihi;
                    Turmodel.BitisTarihi = item.BitisTarihi;
                    Turmodel.Picture = item.Picture;
                    Turmodel.Fiyat = item.Fiyat;
                    Turmodel.ParaBirimi = item.ParaBirimi;
                    Modeltur.Add(Turmodel);
                }
                ViewBag.Baslik = altkategori;
            }

            else if (ulasimturu != null)
            {
                TurBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.Ulasim == ulasimturu).Where(x => x.Durum == true).ToList();
                foreach (var item in TurBilgileri)
                {
                    TurListViewModel Turmodel = new TurListViewModel();
                    Turmodel.TurId = item.TurId;
                    Turmodel.TurBasligi = item.TurBasligi;
                    Turmodel.BaslangicTarihi = item.BaslangicTarihi;
                    Turmodel.BitisTarihi = item.BitisTarihi;
                    Turmodel.Picture = item.Picture;
                    Turmodel.Fiyat = item.Fiyat;
                    Turmodel.ParaBirimi = item.ParaBirimi;
                    Modeltur.Add(Turmodel);
                }
                ViewBag.Baslik2 = ulasimturu;
            }
            return View(Modeltur);
        }
    }
}
