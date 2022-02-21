using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Areas.Admin.Models;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RezervasyonController : Controller
    {
        private readonly IOtelBilgileriService _otelBilgileriService;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IImagesService _imagesService;
        private readonly IAdminRezervasyonService _adminRezervasyonService;
        private readonly IRezervasyonService _rezervasyonService;
        private readonly IOtelService _otelService;
        private readonly IOtelOdaService _otelOdaService;
        private readonly IOtelAdminRezervasyonService _otelAdminRezervasyonService;
        public RezervasyonController(IOtelAdminRezervasyonService otelAdminRezervasyonService, IOtelOdaService otelOdaService, IOtelService otelService, IRezervasyonService rezervasyonService, IOtelBilgileriService otelBilgileriService, ITurBilgileriService turBilgileriService, IImagesService imagesService, IAdminRezervasyonService adminRezervasyonService)
        {
            _otelBilgileriService = otelBilgileriService;
            _turBilgileriService = turBilgileriService;
            _imagesService = imagesService;
            _adminRezervasyonService = adminRezervasyonService;
            _rezervasyonService = rezervasyonService;
            _otelService = otelService;
            _otelOdaService = otelOdaService;
            _otelAdminRezervasyonService = otelAdminRezervasyonService;
        }
        public IActionResult Index()
        {
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
                Turmodel.TurAltKategori = item.TurAltKategori;
                Modeltur.Add(Turmodel);
            }

            return View(Modeltur);
        }
        public IActionResult TurBilgileri(int id)
        {
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
            List<ImagesAdminViewModel> imageModel = new List<ImagesAdminViewModel>();
            foreach (var item in images)
            {
                ImagesAdminViewModel imagesViewModel = new ImagesAdminViewModel();
                imagesViewModel.Id = item.Id;
                imagesViewModel.TurId = item.TurId;
                imagesViewModel.Picture = item.Picture;
                imageModel.Add(imagesViewModel);

            }

            ViewBag.Image = imageModel;
            ViewBag.sayi = images.Count();

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirHepsi().Where(x => x.TurId == id).ToList();
            List<OtelBilgiAdminViewModel> ModelOtel = new List<OtelBilgiAdminViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelBilgiAdminViewModel Otelmodel = new OtelBilgiAdminViewModel();
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

        [HttpGet]
        public IActionResult Rezervasyon(int yetiskin, int cocuk, int TurId, int id)
        {

            ViewBag.otelid = id;
            ViewBag.TurId = TurId;

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == id).ToList();
            List<OtelAdminViewModel> ModelOtel = new List<OtelAdminViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelAdminViewModel Otelmodel = new OtelAdminViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                Otelmodel.Picture = item.TurBilgileris.Picture;
                Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
                Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = yetiskin * item.CiftKisilikOda + cocuk * item.Cocuk_3_6_Yas;
                ViewBag.baslangic = item.TurBilgileris.BaslangicTarihi;
                ViewBag.bitis = item.TurBilgileris.BitisTarihi;
            }
            ViewBag.Yetiskin = yetiskin;
            ViewBag.Cocuk = cocuk;
            ViewBag.OtelBilgi = ModelOtel;


            return View(new RezervasyonAdminViewModel());
        }

        [HttpPost]
        public IActionResult Rezervasyon(RezervasyonAdminViewModel model, int yetiskin, int cocuk, int id, int TurId, double odenecek, DateTime bas, DateTime bit)
        {

            if (ModelState.IsValid)
            {
                _adminRezervasyonService.Kaydet(new AdminRezervasyon
                {
                    Id = model.RezervasyonId,
                    TurId = TurId,
                    Yad = model.Yad,
                    Ysoyad = model.Ysoyad,
                    Ycinsiyet = model.Ycinsiyet,
                    Ytc = model.Ytc,
                    Telefon = model.Telefon,
                    Email = model.Email,
                    Durum = true,
                    OtelId = id,
                    CocukSayisi = cocuk,
                    YetiskinSayisi = yetiskin,
                    Tarih = DateTime.Now,
                    OdenecekTutar = odenecek,
                    Baslangic = bas,
                    Bitis = bit
                });

                return RedirectToAction("Index");
            }

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == id).ToList();
            List<OtelAdminViewModel> ModelOtel = new List<OtelAdminViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelAdminViewModel Otelmodel = new OtelAdminViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                Otelmodel.Picture = item.TurBilgileris.Picture;
                Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
                Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = yetiskin * item.CiftKisilikOda + cocuk * item.Cocuk_3_6_Yas;
                ViewBag.baslangic = item.TurBilgileris.BaslangicTarihi;
                ViewBag.bitis = item.TurBilgileris.BitisTarihi;
            }

            ViewBag.Yetiskin = yetiskin;
            ViewBag.Cocuk = cocuk;
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.otelid = id;
            ViewBag.TurId = TurId;

            return View(model);
        }
        public IActionResult IptalEt(int id)
        {
            var tur = _adminRezervasyonService.GetirIdile(id);
            RezervasyonAdminViewModel model = new RezervasyonAdminViewModel
            {
                TurId = tur.TurId,
                OtelId = tur.OtelId,
                RezervasyonId = tur.Id,
                Yad = tur.Yad,
                Ycinsiyet = tur.Ycinsiyet,
                Ysoyad = tur.Ysoyad,
                Tarih = tur.Tarih,
                Telefon = tur.Email,
                Email = tur.Email,
                CocukSayisi = tur.CocukSayisi,
                YetiskinSayisi = tur.YetiskinSayisi,
                OdenecekTutar = tur.OdenecekTutar,
                Ytc = tur.Ytc
            };

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == tur.OtelId).ToList();
            List<OtelAdminViewModel> ModelOtel = new List<OtelAdminViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelAdminViewModel Otelmodel = new OtelAdminViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                Otelmodel.Picture = item.TurBilgileris.Picture;
                Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
                Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
                ModelOtel.Add(Otelmodel);
            }
            ViewBag.Yetiskin = tur.YetiskinSayisi;
            ViewBag.Cocuk = tur.CocukSayisi;
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.otelid = tur.OtelId;
            ViewBag.TurId = tur.TurId;
            return View(model);
        }
        [HttpPost]
        public IActionResult Kaldir(int id)
        {
            var getir = _adminRezervasyonService.GetirIdile(id);
            getir.Durum = false;
            _adminRezervasyonService.Guncelle(getir);
            return RedirectToAction("IptalTurRezervasyonlar", "Dokumantasyon");
        }

        public IActionResult Anamenu()
        {
            return View();
        }
        public IActionResult OtelIndex()
        {
            List<Otel> otel = _otelService.GetirHepsi().ToList();
            List<OtelAdminListeViewModel> modelotel = new List<OtelAdminListeViewModel>();
            foreach (var item in otel)
            {
                OtelAdminListeViewModel otelmodel = new OtelAdminListeViewModel();
                otelmodel.OtelAd = item.OtelAd;
                otelmodel.OtelId = item.OtelId;
                otelmodel.Sehir = item.Sehir;
                otelmodel.Picture = item.Picture;
                otelmodel.Anagrup = item.Anagrup;
                modelotel.Add(otelmodel);
            }

            return View(modelotel);
        }
        public IActionResult OtelOdaBilgileri(int id)
        {
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
                otelmodel.OtelId = item.OtelId;
                //otelmodel.OtelOdaOzellik = item.OtelOdaOzellik;
                //otelmodel.OtelOzellik = item.Otels.OtelOzellik;
                model.Add(otelmodel);

            }
            return View(model);
        }

        public IActionResult OtelRezervasyon(int otelid, int id)
        {

            List<OtelOda> OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == id).ToList();
            List<OtelOdaViewModel> ModelOtel = new List<OtelOdaViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelOdaViewModel Otelmodel = new OtelOdaViewModel();
                Otelmodel.Id = item.Id;
                Otelmodel.OtelId = item.OtelId;
                Otelmodel.OtelAd = item.Otels.OtelAd;
                Otelmodel.GirisTarihi = item.GirisTarihi;
                Otelmodel.CikisTarihi = item.CikisTarihi;
                //Otelmodel.Sehir = item.Otels.Sehir;
                Otelmodel.Picture = item.Otels.Picture;
                Otelmodel.OdaTipi = item.OdaTipi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = item.Fiyat;
                ViewBag.ParaBirimi = item.ParaBirimi;
                ViewBag.Giris = item.GirisTarihi;
                ViewBag.Cikis = item.CikisTarihi;
            }
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.OtelId = otelid;
            ViewBag.OtelOdaId = id;
            return View(new OtelAdminRezervasyonViewModel());
        }
        [HttpPost]
        public IActionResult OtelRezervasyon(OtelAdminRezervasyonViewModel model, int otelid, int otelodaid, int odenen, DateTime giris, DateTime cikis)
        {
            if (ModelState.IsValid)
            {
                _otelAdminRezervasyonService.Kaydet(new OtelAdminRezervasyon
                {
                    Id = model.RezerId,
                    OtelId = otelid,
                    OtelOdaId = otelodaid,
                    OdenecekTutar = odenen,
                    BaslangicTarih = giris,
                    BitisTarih = cikis,
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Tarih = DateTime.Now,
                    Tc = model.Tc,
                    Cinsiyet = model.Cinsiyet,
                    Email = model.Email,
                    Telefon = model.Telefon,
                    Durum = true
                });

                return RedirectToAction("OtelRezervasyonListe", "Dokumantasyon");
            }


            List<OtelOda> OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == otelodaid).ToList();
            List<OtelOdaViewModel> ModelOtel = new List<OtelOdaViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelOdaViewModel Otelmodel = new OtelOdaViewModel();
                Otelmodel.Id = item.Id;
                Otelmodel.OtelId = item.OtelId;
                Otelmodel.OtelAd = item.Otels.OtelAd;
                Otelmodel.GirisTarihi = item.GirisTarihi;
                Otelmodel.CikisTarihi = item.CikisTarihi;
                Otelmodel.Picture = item.Otels.Picture;
                Otelmodel.OdaTipi = item.OdaTipi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = item.Fiyat;
                ViewBag.ParaBirimi = item.ParaBirimi;
                ViewBag.Giris = item.GirisTarihi;
                ViewBag.Cikis = item.CikisTarihi;
            }
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.OtelId = otelid;
            ViewBag.OtelOdaId = otelodaid;

            return View(model);
        }

     
        public IActionResult OtelRezervasyonIptal(int id)
        {
            var tur = _otelAdminRezervasyonService.GetirIdile(id);
            OtelAdminRezervasyonListeViewModel model = new OtelAdminRezervasyonListeViewModel
            {
                Id = tur.Id,
                OtelId = tur.OtelId,
                Ad = tur.Ad,
                Cinsiyet = tur.Cinsiyet,
                Soyad = tur.Soyad,
                Tarih = tur.Tarih,
                Telefon = tur.Email,
                Email = tur.Email,
                OdenecekTutar = tur.OdenecekTutar,
                Tc = tur.Tc
            };


            List<OtelOda> OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == tur.OtelId).ToList();
            List<OtelOdaViewModel> ModelOtel = new List<OtelOdaViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelOdaViewModel Otelmodel = new OtelOdaViewModel();
                Otelmodel.Id = item.Id;
                Otelmodel.OtelId = item.OtelId;
                Otelmodel.OtelAd = item.Otels.OtelAd;
                Otelmodel.GirisTarihi = item.GirisTarihi;
                Otelmodel.CikisTarihi = item.CikisTarihi;
                Otelmodel.Picture = item.Otels.Picture;
                Otelmodel.OdaTipi = item.OdaTipi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = item.Fiyat;
                ViewBag.ParaBirimi = item.ParaBirimi;
                ViewBag.Giris = item.GirisTarihi;
                ViewBag.Cikis = item.CikisTarihi;
            }
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.OtelId =tur.OtelId;
            ViewBag.OtelOdaId = tur.OtelOdaId;
            return View(model);
        }

        [HttpPost]
        public IActionResult IptalEtOtel(int id)
        {
            var getir = _otelAdminRezervasyonService.GetirIdile(id);
            getir.Durum = false;
            _otelAdminRezervasyonService.Guncelle(getir);
            return RedirectToAction("IptalOtelRezervasyonListe", "Dokumantasyon");
        }
    }
}
