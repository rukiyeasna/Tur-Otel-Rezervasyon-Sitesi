using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Areas.Member.Models;

namespace TS.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class OtelController : Controller
    {
        private readonly IOtelService _otelService;
        private readonly IOtelOdaService _otelOdaService;
        private readonly IOtelImageService _otelImageService;
        private readonly IOtelOdaImageService _otelOdaImageService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOtelFavoriService _otelFavoriService;
        private readonly IOtelOzellikService _otelOzellikService;
        private readonly IOtelOdaOzellikService _otelOdaOzellikService;
        private readonly IOtelPuanService _otelPuanService;
        public double toplam { get; set; }
        public double toplam1 { get; set; }
        public OtelController(IOtelFavoriService otelFavoriService, UserManager<AppUser> userManager, IOtelOdaService otelOdaService, IOtelService otelService, IOtelImageService otelImageService, IOtelOdaImageService otelOdaImageService, IOtelOzellikService otelOzellikService, IOtelOdaOzellikService otelOdaOzellikService, IOtelPuanService otelPuanService)
        {
            _otelService = otelService;
            _otelImageService = otelImageService;
            _otelOdaImageService = otelOdaImageService;
            _otelOdaService = otelOdaService;
            _userManager = userManager;
            _otelFavoriService = otelFavoriService;
            _otelOdaOzellikService = otelOdaOzellikService;
            _otelOzellikService = otelOzellikService;
            _otelPuanService = otelPuanService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> SehirOtel(string sehir)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullaniciId = appUser.Id;

            List<Otel> otel = _otelService.GetirHepsi().Where(x => x.Sehir == sehir).ToList();
            List<OtelListeViewModel> modelotel = new List<OtelListeViewModel>();
            foreach (var item in otel)
            {
                OtelListeViewModel otelmodel = new OtelListeViewModel();
                otelmodel.OtelAd = item.OtelAd;
                otelmodel.OtelId = item.OtelId;
                otelmodel.Sehir = item.Sehir;
                otelmodel.Picture = item.Picture;
                modelotel.Add(otelmodel);
            }
            ViewBag.OtelSehri = sehir;
            return View(modelotel);
        }

        public IActionResult OtelBilgileri(int id, string? otelad, string sehir)
        {
            List<OtelOzellik> getir = _otelOzellikService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            List<OtelOzellikMemberViewModel> turBilgileris = new List<OtelOzellikMemberViewModel>();
            foreach (var item in getir)
            {
                OtelOzellikMemberViewModel turModel = new OtelOzellikMemberViewModel();
                turModel.Ozellik = item.Ozellik;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;
            ViewBag.OtelSehri = sehir;

            List<OtelImage> images = _otelImageService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            List<OtelImageViewModel> imageModel = new List<OtelImageViewModel>();
            foreach (var item in images)
            {
                OtelImageViewModel imagesViewModel = new OtelImageViewModel();
                imagesViewModel.Id = item.Id;
                imagesViewModel.OtelId = item.OtelId;
                imagesViewModel.Picture = item.Picture;
                imageModel.Add(imagesViewModel);

            }
            ViewBag.Image = imageModel;
            ViewBag.sayi = images.Count();
            ViewBag.Otelad = otelad;

            List<OtelOda> otel = _otelOdaService.GetirOtelBilgileri().Where(x => x.OtelId == id).ToList();
            List<OtelOdaViewModel> model = new List<OtelOdaViewModel>();
            foreach (var item in otel)
            {
                OtelOdaViewModel otelmodel = new OtelOdaViewModel();
                otelmodel.Id = item.Id;
                otelmodel.OtelAd = item.Otels.OtelAd;
                otelmodel.OdaTipi = item.OdaTipi;
                otelmodel.Picture = item.Picture;
                otelmodel.IcerikBilgisi = item.IcerikBilgisi;
                otelmodel.GirisTarihi = item.GirisTarihi;
                otelmodel.CikisTarihi = item.CikisTarihi;
                otelmodel.Bilgi = item.Bilgi;
                otelmodel.Fiyat = item.Fiyat;
                otelmodel.OtelOdaOzellik = item.OtelOdaOzellik;
                otelmodel.OtelOzellik = item.Otels.OtelOzellik;
                model.Add(otelmodel);

                ViewBag.Ozellik = item.Otels.OtelOzellik;
            }

            List<OtelPuan> otelPuans = _otelPuanService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            var sayi = otelPuans.Count;
            List<PuanViewModel> puan = new List<PuanViewModel>();
            foreach (var item in otelPuans)
            {

                PuanViewModel puanmodel = new PuanViewModel();
                puanmodel.Toplam = item.FiyatDeger + item.HizmetDeger + item.TemizDeger + item.PersonelDeger + item.YiyecekDeger + item.OdaDeger;
                toplam = toplam + puanmodel.Toplam;
                ViewBag.ToplamPuan = toplam;
                toplam = toplam;
            }

            double deger = toplam / (sayi * 6);
            ViewBag.Ortalama = Math.Round(deger, 1);


            List<OtelPuan> otelPuansyorum = _otelPuanService.GetirHepsi().Where(x => x.OtelId == id).Where(x => x.Yorum != null).ToList();
            List<PuanViewModel> yorum = new List<PuanViewModel>();
            foreach (var item in otelPuansyorum)
            {              
                    PuanViewModel yorums = new PuanViewModel();
                    yorums.Yorum = item.Yorum;
                    yorums.Username = item.Username;
                    yorum.Add(yorums);               
            }
            ViewBag.YorumSayisi = otelPuansyorum.Count;
            ViewBag.Yorumlar = yorum;

            return View(model);

        }

        public IActionResult OtelOdaBilgileri(int id, string? otelad)
        {
            List<OtelOdaOzellik> getir = _otelOdaOzellikService.GetirHepsi().Where(x => x.OtelOdaId == id).ToList();
            List<OtelOdaOzellikMemberViewModel> turBilgileris = new List<OtelOdaOzellikMemberViewModel>();
            foreach (var item in getir)
            {
                OtelOdaOzellikMemberViewModel turModel = new OtelOdaOzellikMemberViewModel();
                turModel.Ozellik = item.Ozellik;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;



            List<OtelOdaImage> images = _otelOdaImageService.GetirHepsi().Where(x => x.OtelOdaId == id).ToList();
            List<OtelOdaImageViewModel> imageModel = new List<OtelOdaImageViewModel>();
            foreach (var item in images)
            {
                OtelOdaImageViewModel imagesViewModel = new OtelOdaImageViewModel();
                imagesViewModel.Id = item.Id;
                //imagesViewModel.OtelId = item.OtelId;
                imagesViewModel.Picture = item.Picture;
                imageModel.Add(imagesViewModel);

            }
            ViewBag.Image = imageModel;
            ViewBag.sayi = images.Count();
            ViewBag.Otelad = otelad;
            List<OtelOda> otel = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == id).ToList();
            List<OtelOdaViewModel> model = new List<OtelOdaViewModel>();
            foreach (var item in otel)
            {
                OtelOdaViewModel otelmodel = new OtelOdaViewModel();
                otelmodel.Id = item.Id;
                otelmodel.OtelAd = item.Otels.OtelAd;
                otelmodel.OdaTipi = item.OdaTipi;
                otelmodel.Picture = item.Picture;
                otelmodel.IcerikBilgisi = item.IcerikBilgisi;
                otelmodel.GirisTarihi = item.GirisTarihi;
                otelmodel.CikisTarihi = item.CikisTarihi;
                otelmodel.Bilgi = item.Bilgi;
                otelmodel.Fiyat = item.Fiyat;
                otelmodel.OtelOdaOzellik = item.OtelOdaOzellik;
                otelmodel.OtelOzellik = item.Otels.OtelOzellik;
                otelmodel.OtelId = item.OtelId;
                model.Add(otelmodel);

                ViewBag.OtelId = item.OtelId;
                ViewBag.OdaTipi = item.OdaTipi;
                ViewBag.Ozellik = item.OtelOdaOzellik;
            }

            ViewBag.OtelOdaId = id;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Arama(string sehir, DateTime baslangic, DateTime bitis)
        {
            ViewBag.baslangic = baslangic;
            ViewBag.bitis = bitis;
            ViewBag.kategori = sehir;

            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullaniciId = appUser.Id;


            List<OtelOda> OtelBilgileri;
            List<OtelOdaViewModel> model = new List<OtelOdaViewModel>();

            if (sehir != "null" && baslangic != null && bitis != null)
            {
                OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.GirisTarihi >= baslangic).Where(x => x.CikisTarihi <= bitis).Where(x => x.Otels.Sehir == sehir).ToList();
                foreach (var item in OtelBilgileri)
                {
                    OtelOdaViewModel otelmodel = new OtelOdaViewModel();
                    otelmodel.Id = item.Id;
                    otelmodel.OtelAd = item.Otels.OtelAd;
                    otelmodel.OdaTipi = item.OdaTipi;
                    otelmodel.Picture = item.Picture;
                    otelmodel.IcerikBilgisi = item.IcerikBilgisi;
                    otelmodel.GirisTarihi = item.GirisTarihi;
                    otelmodel.CikisTarihi = item.CikisTarihi;
                    otelmodel.Bilgi = item.Bilgi;
                    otelmodel.Fiyat = item.Fiyat;
                    otelmodel.OtelOdaOzellik = item.OtelOdaOzellik;
                    otelmodel.OtelOzellik = item.Otels.OtelOzellik;
                    otelmodel.Sehir = item.Otels.Sehir;
                    otelmodel.OtelId = item.OtelId;
                    model.Add(otelmodel);
                }
                ViewBag.sayi = OtelBilgileri.Count();
                //return View(Modeltur);
            }

            else if (sehir == "null" && baslangic != null && bitis != null)
            {
                OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.GirisTarihi >= baslangic).Where(x => x.CikisTarihi <= bitis).ToList();
                foreach (var item in OtelBilgileri)
                {
                    OtelOdaViewModel otelmodel = new OtelOdaViewModel();
                    otelmodel.Id = item.Id;
                    otelmodel.OtelAd = item.Otels.OtelAd;
                    otelmodel.OdaTipi = item.OdaTipi;
                    otelmodel.Picture = item.Picture;
                    otelmodel.IcerikBilgisi = item.IcerikBilgisi;
                    otelmodel.GirisTarihi = item.GirisTarihi;
                    otelmodel.CikisTarihi = item.CikisTarihi;
                    otelmodel.Bilgi = item.Bilgi;
                    otelmodel.Fiyat = item.Fiyat;
                    otelmodel.OtelOdaOzellik = item.OtelOdaOzellik;
                    otelmodel.OtelOzellik = item.Otels.OtelOzellik;
                    otelmodel.Sehir = item.Otels.Sehir;
                    otelmodel.OtelId = item.OtelId;
                    model.Add(otelmodel);
                }
                ViewBag.sayi = OtelBilgileri.Count();
            }
            return View(model);

        }

        public IActionResult Favori(int userId, int otelId)
        {
            List<OtelFavori> favori = _otelFavoriService.GetirHepsi().Where(x => x.AppUserId == userId).ToList();
            OtelFavoriListViewModel favoriListViewModel = new OtelFavoriListViewModel();
            foreach (var item in favori)
            {
                if (item.OtelId == otelId)
                {
                    return RedirectToAction("Favorilerim", "Home");
                }

            }

            OtelFavoriEkleViewModel model = new OtelFavoriEkleViewModel();
            if (ModelState.IsValid)
            {
                _otelFavoriService.Kaydet(new OtelFavori
                {
                    Id = model.Id,
                    AppUserId = userId,
                    OtelId = otelId
                });
                return RedirectToAction("Favorilerim", "Home");
            }
            return View();
        }

        public IActionResult FavoriKaldır(int id)
        {
            _otelFavoriService.Sil(new OtelFavori { Id = id });
            return RedirectToAction("Favorilerim", "Home");
        }

        public IActionResult Filter(string anagrup, string bilgi, string ozellik, int sayi)
        {
            //List<Otel> OtelBilgileri;
            //List<OtelViewModel> model = new List<OtelViewModel>();
            List<OtelListeViewModel> modelotel = new List<OtelListeViewModel>();
            if (anagrup != null)
            {
                List<Otel> otel = _otelService.GetirHepsi().Where(x => x.Anagrup == anagrup).ToList();

                foreach (var item in otel)
                {
                    OtelListeViewModel otelmodel = new OtelListeViewModel();
                    otelmodel.OtelAd = item.OtelAd;
                    otelmodel.OtelId = item.OtelId;
                    otelmodel.Sehir = item.Sehir;
                    otelmodel.Picture = item.Picture;
                    modelotel.Add(otelmodel);
                }

            }

            else if (bilgi != null)
            {
                List<OtelOda> otel = _otelOdaService.GetirOtelBilgileri().Where(x => x.Bilgi == bilgi).ToList();

                foreach (var item in otel)
                {
                    OtelListeViewModel otelmodel = new OtelListeViewModel();
                    otelmodel.OtelAd = item.Otels.OtelAd;
                    otelmodel.OtelId = item.OtelId;
                    otelmodel.Sehir = item.Otels.Sehir;
                    otelmodel.Picture = item.Otels.Picture;
                    modelotel.Add(otelmodel);
                }
            }

            else if (ozellik != null)
            {
                List<OtelOzellik> otel = _otelOzellikService.GetirOtelOzellikBilgileri().Where(x => x.Ozellik == ozellik).ToList();

                foreach (var item in otel)
                {
                    OtelListeViewModel otelmodel = new OtelListeViewModel();
                    otelmodel.OtelAd = item.Otels.OtelAd;
                    otelmodel.OtelId = item.OtelId;
                    otelmodel.Sehir = item.Otels.Sehir;
                    otelmodel.Picture = item.Otels.Picture;
                    modelotel.Add(otelmodel);
                }
            }

            //else if (sayi != null)
            //{
            //    List<OtelPuan> otelPuans = _otelPuanService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            //    var sayi = otelPuans.Count;
            //    List<PuanViewModel> puan = new List<PuanViewModel>();
            //    foreach (var item in otelPuans)
            //    {

            //        PuanViewModel puanmodel = new PuanViewModel();
            //        puanmodel.Toplam = item.FiyatDeger + item.HizmetDeger + item.TemizDeger + item.PersonelDeger + item.YiyecekDeger + item.OdaDeger;
            //        toplam = toplam + puanmodel.Toplam;
            //        ViewBag.ToplamPuan = toplam;
            //        toplam = toplam;
            //    }
            //    //ViewBag.Ortalama =toplam / (sayi*6);
            //    double deger = toplam / (sayi * 6);
            //    ViewBag.Ortalama = Math.Round(deger, 1);
            //}
            return View(modelotel);
        }
    }
}
