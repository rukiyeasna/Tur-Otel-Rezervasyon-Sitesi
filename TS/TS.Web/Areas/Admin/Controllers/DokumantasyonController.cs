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
    public class DokumantasyonController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IRezervasyonService _rezervasyonService;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly IAdminRezervasyonService _adminRezervasyonService;
        private readonly IOtelAdminRezervasyonService _otelAdminRezervasyonService;
        private readonly IOtelRezervasyonService _otelRezervasyonService;
        public DokumantasyonController(IOtelRezervasyonService otelRezervasyonService, IOtelAdminRezervasyonService otelAdminRezervasyonService, IAppUserService appUserService, IRezervasyonService rezervasyonService, ITurBilgileriService turBilgileriService, IAdminRezervasyonService adminRezervasyonService)
        {
            _appUserService = appUserService;
            _rezervasyonService = rezervasyonService;
            _turBilgileriService = turBilgileriService;
            _adminRezervasyonService = adminRezervasyonService;
            _otelAdminRezervasyonService = otelAdminRezervasyonService;
            _otelRezervasyonService = otelRezervasyonService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KullaniciBilgileri()
        {
            List<AppUser> kullanici = _appUserService.GetirHepsi().Where(x => x.UserName != "rukiye").ToList();
            List<KullaniciListeViewModel> model = new List<KullaniciListeViewModel>();
            foreach (var item in kullanici)
            {
                KullaniciListeViewModel kullaniciModel = new KullaniciListeViewModel();
                kullaniciModel.Id = item.Id;
                kullaniciModel.Name = item.Name;
                kullaniciModel.Surname = item.Surname;
                kullaniciModel.Username = item.UserName;
                kullaniciModel.Email = item.Email;
                kullaniciModel.Telefon = item.PhoneNumber;
                model.Add(kullaniciModel);

            }
            return View(model);
        }

        public IActionResult TurRezervasyonlar()
        {
            List<TurViewModel> modelid = new List<TurViewModel>();
            var list = _rezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.Baslangic >= DateTime.Now).ToList();
            var grup = from b in list
                       group b by new { b.TurId, b.TurBilgileris.TurBasligi } into g
                       select new
                       {
                           TurId = g.Key.TurId,
                           TurBasligi = g.Key.TurBasligi
                       };
            foreach (var resultg in grup)
            {
                TurViewModel deneme = new TurViewModel();
                deneme.TurId = resultg.TurId;
                deneme.TurBasligi = resultg.TurBasligi;
                modelid.Add(deneme);
            }

            List<TurViewModel> modelids = new List<TurViewModel>();
            var lists = _adminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.Baslangic >= DateTime.Now).ToList();
            var grups = from b in lists
                        group b by new { b.TurId, b.TurBilgileris.TurBasligi } into g
                        select new
                        {
                            TurId = g.Key.TurId,
                            TurBasligi = g.Key.TurBasligi
                        };
            foreach (var resultg in grups)
            {
                TurViewModel deneme = new TurViewModel();
                deneme.TurId = resultg.TurId;
                deneme.TurBasligi = resultg.TurBasligi;
                modelids.Add(deneme);
            }
            ViewBag.odenmemis = modelids;
            ViewBag.Say = modelids.Count;
            return View(modelid);
        }
        public IActionResult TurRezervasyonListe(int id)
        {
            List<Rezervasyon> tur = _rezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.TurId == id).Where(x => x.Baslangic >= DateTime.Now).ToList();
            List<RezerViewModel> model = new List<RezerViewModel>();
            foreach (var item in tur)
            {
                RezerViewModel turModel = new RezerViewModel();
                turModel.RezervasyonId = item.Id;
                turModel.TurId = item.TurId;
                turModel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                turModel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                turModel.Yad = item.Yad;
                turModel.Ysoyad = item.Ysoyad;
                turModel.Picture = item.TurBilgileris.Picture;
                turModel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                turModel.Email = item.Email;
                turModel.Telefon = item.Telefon;
                turModel.YetiskinSayisi = item.YetiskinSayisi;
                turModel.CocukSayisi = item.CocukSayisi;
                turModel.TurBasligi = item.TurBilgileris.TurBasligi;
                turModel.OdenenTutar = item.OdenenTutar;
                model.Add(turModel);
            }

            List<AdminRezervasyon> turs = _adminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.Baslangic >= DateTime.Now).Where(x => x.TurId == id).ToList();
            List<AdminRezerViewModel> models = new List<AdminRezerViewModel>();
            foreach (var item in turs)
            {
                AdminRezerViewModel turModels = new AdminRezerViewModel();
                turModels.RezervasyonId = item.Id;
                turModels.TurId = item.TurId;
                turModels.Baslangic = item.Baslangic;
                turModels.Bitis = item.Bitis;
                turModels.Yad = item.Yad;
                turModels.Ysoyad = item.Ysoyad;
                turModels.Picture = item.TurBilgileris.Picture;
                turModels.TurAltKategori = item.TurBilgileris.TurAltKategori;
                turModels.Email = item.Email;
                turModels.Telefon = item.Telefon;
                turModels.YetiskinSayisi = item.YetiskinSayisi;
                turModels.CocukSayisi = item.CocukSayisi;
                turModels.TurBasligi = item.TurBilgileris.TurBasligi;
                turModels.OdenecekTutar = item.OdenecekTutar;
                models.Add(turModels);
            }
            ViewBag.rezervasyon = models;
            return View(model);
        }

        public IActionResult IptalTurRezervasyonlar()
        {
            List<Rezervasyon> tur = _rezervasyonService.GetirTumTablolarla().Where(x => x.Durum == false).ToList();
            List<RezerViewModel> model = new List<RezerViewModel>();
            foreach (var item in tur)
            {
                RezerViewModel turModel = new RezerViewModel();
                turModel.RezervasyonId = item.Id;
                turModel.TurId = item.TurId;
                turModel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                turModel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                turModel.Yad = item.Yad;
                turModel.Ysoyad = item.Ysoyad;
                turModel.Picture = item.TurBilgileris.Picture;
                turModel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                turModel.Email = item.Email;
                turModel.Telefon = item.Telefon;
                turModel.YetiskinSayisi = item.YetiskinSayisi;
                turModel.CocukSayisi = item.CocukSayisi;
                turModel.TurBasligi = item.TurBilgileris.TurBasligi;
                turModel.OdenenTutar = item.OdenenTutar;
                model.Add(turModel);
            }

            List<AdminRezervasyon> turs = _adminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == false).ToList();
            List<RezerAdminViewModel> models = new List<RezerAdminViewModel>();
            foreach (var item in turs)
            {
                RezerAdminViewModel turModels = new RezerAdminViewModel();
                turModels.RezervasyonId = item.Id;
                turModels.TurId = item.TurId;
                turModels.Baslangic = item.Baslangic;
                turModels.Bitis = item.Bitis;
                turModels.Yad = item.Yad;
                turModels.Ysoyad = item.Ysoyad;
                turModels.Picture = item.TurBilgileris.Picture;
                turModels.TurAltKategori = item.TurBilgileris.TurAltKategori;
                turModels.Email = item.Email;
                turModels.Telefon = item.Telefon;
                turModels.YetiskinSayisi = item.YetiskinSayisi;
                turModels.CocukSayisi = item.CocukSayisi;
                turModels.TurBasligi = item.TurBilgileris.TurBasligi;
                turModels.OdenecekTutar = item.OdenecekTutar;
                models.Add(turModels);
            }
            ViewBag.Model = models;
            return View(model);
        }
        public IActionResult GecmisTurRezervasyonlar()
        {
            List<Rezervasyon> tur = _rezervasyonService.GetirTumTablolarla().Where(x => x.Baslangic < DateTime.Now).ToList();
            List<RezerViewModel> model = new List<RezerViewModel>();
            foreach (var item in tur)
            {
                RezerViewModel turModel = new RezerViewModel();
                turModel.RezervasyonId = item.Id;
                turModel.TurId = item.TurId;
                turModel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                turModel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                turModel.Yad = item.Yad;
                turModel.Ysoyad = item.Ysoyad;
                turModel.Picture = item.TurBilgileris.Picture;
                turModel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                turModel.Email = item.Email;
                turModel.Telefon = item.Telefon;
                turModel.YetiskinSayisi = item.YetiskinSayisi;
                turModel.CocukSayisi = item.CocukSayisi;
                turModel.TurBasligi = item.TurBilgileris.TurBasligi;
                turModel.OdenenTutar = item.OdenenTutar;
                model.Add(turModel);
            }
            return View(model);
        }
        public IActionResult TurRezervasyonListe2(int id)
        {

            List<AdminRezervasyon> turs = _adminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.TurId == id).ToList();
            List<AdminRezerViewModel> models = new List<AdminRezerViewModel>();
            foreach (var item in turs)
            {
                AdminRezerViewModel turModels = new AdminRezerViewModel();
                turModels.RezervasyonId = item.Id;
                turModels.TurId = item.TurId;
                turModels.Baslangic = item.Baslangic;
                turModels.Bitis = item.Bitis;
                turModels.Yad = item.Yad;
                turModels.Ysoyad = item.Ysoyad;
                turModels.Picture = item.TurBilgileris.Picture;
                turModels.TurAltKategori = item.TurBilgileris.TurAltKategori;
                turModels.Email = item.Email;
                turModels.Telefon = item.Telefon;
                turModels.YetiskinSayisi = item.YetiskinSayisi;
                turModels.CocukSayisi = item.CocukSayisi;
                turModels.TurBasligi = item.TurBilgileris.TurBasligi;
                turModels.OdenecekTutar = item.OdenecekTutar;
                models.Add(turModels);
            }
            return View(models);
        }
        public IActionResult OtelRezervasyonListe()
        {
            List<OtelRezervasyon> tur = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.BaslangicTarih >= DateTime.Now).ToList();
            List<OtelRezervasyonViewModel> model = new List<OtelRezervasyonViewModel>();
            foreach (var item in tur)
            {
                OtelRezervasyonViewModel turModel = new OtelRezervasyonViewModel();
                turModel.Id = item.Id;
                turModel.Telefon = item.Telefon;
                turModel.Email = item.Email;
                turModel.BaslangicTarih = item.BaslangicTarih;
                turModel.BitisTarih = item.BitisTarih;
                turModel.Ad = item.Ad;
                turModel.Soyad = item.Soyad;
                turModel.Tc = item.Tc;
                turModel.OtelAd = item.Otels.OtelAd;
                turModel.Picture = item.Otels.Picture;
                turModel.OdaTipi = item.OtelOdas.OdaTipi;
                turModel.OdenenTutar = item.OdenenTutar;
                model.Add(turModel);
            }

            List<OtelAdminRezervasyon> turs = _otelAdminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.BaslangicTarih >= DateTime.Now).ToList();
            List<OtelAdminRezervasyonListeViewModel> models = new List<OtelAdminRezervasyonListeViewModel>();
            foreach (var item in turs)
            {
                OtelAdminRezervasyonListeViewModel turModels = new OtelAdminRezervasyonListeViewModel();
                turModels.Id = item.Id;
                turModels.Telefon = item.Telefon;
                turModels.Email = item.Email;
                turModels.BaslangicTarih = item.BaslangicTarih;
                turModels.BitisTarih = item.BitisTarih;
                turModels.Ad = item.Ad;
                turModels.Soyad = item.Soyad;
                turModels.Tc = item.Tc;
                turModels.OtelAd = item.Otels.OtelAd;
                turModels.Picture = item.Otels.Picture;
                turModels.OdaTipi = item.OtelOdas.OdaTipi;
                turModels.OdenecekTutar = item.OdenecekTutar;
                models.Add(turModels);
            }
            ViewBag.rezervasyon = models;
            return View(model);
        }

        public IActionResult IptalOtelRezervasyonListe()
        {
            List<OtelRezervasyon> tur = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == false).Where(x => x.BaslangicTarih >= DateTime.Now).ToList();
            List<OtelRezervasyonViewModel> model = new List<OtelRezervasyonViewModel>();
            foreach (var item in tur)
            {
                OtelRezervasyonViewModel turModel = new OtelRezervasyonViewModel();
                turModel.Id = item.Id;
                turModel.Telefon = item.Telefon;
                turModel.Email = item.Email;
                turModel.BaslangicTarih = item.BaslangicTarih;
                turModel.BitisTarih = item.BitisTarih;
                turModel.Ad = item.Ad;
                turModel.Soyad = item.Soyad;
                turModel.Tc = item.Tc;
                turModel.OtelAd = item.Otels.OtelAd;
                turModel.Picture = item.Otels.Picture;
                turModel.OdaTipi = item.OtelOdas.OdaTipi;
                turModel.OdenenTutar = item.OdenenTutar;
                model.Add(turModel);
            }

            List<OtelAdminRezervasyon> turs = _otelAdminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == false).Where(x => x.BaslangicTarih >= DateTime.Now).ToList();
            List<OtelAdminRezervasyonListeViewModel> models = new List<OtelAdminRezervasyonListeViewModel>();
            foreach (var item in turs)
            {
                OtelAdminRezervasyonListeViewModel turModels = new OtelAdminRezervasyonListeViewModel();
                turModels.Id = item.Id;
                turModels.Telefon = item.Telefon;
                turModels.Email = item.Email;
                turModels.BaslangicTarih = item.BaslangicTarih;
                turModels.BitisTarih = item.BitisTarih;
                turModels.Ad = item.Ad;
                turModels.Soyad = item.Soyad;
                turModels.Tc = item.Tc;
                turModels.OtelAd = item.Otels.OtelAd;
                turModels.Picture = item.Otels.Picture;
                turModels.OdaTipi = item.OtelOdas.OdaTipi;
                turModels.OdenecekTutar = item.OdenecekTutar;
                models.Add(turModels);
            }
            ViewBag.rezervasyon = models;
            return View(model);
        }

        public IActionResult GecmisOtelRezervasyonListe()
        {
            List<OtelRezervasyon> tur = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.BaslangicTarih <= DateTime.Now).ToList();
            List<OtelRezervasyonViewModel> model = new List<OtelRezervasyonViewModel>();
            foreach (var item in tur)
            {
                OtelRezervasyonViewModel turModel = new OtelRezervasyonViewModel();
                turModel.Id = item.Id;
                turModel.Telefon = item.Telefon;
                turModel.Email = item.Email;
                turModel.BaslangicTarih = item.BaslangicTarih;
                turModel.BitisTarih = item.BitisTarih;
                turModel.Ad = item.Ad;
                turModel.Soyad = item.Soyad;
                turModel.Tc = item.Tc;
                turModel.OtelAd = item.Otels.OtelAd;
                turModel.Picture = item.Otels.Picture;
                turModel.OdaTipi = item.OtelOdas.OdaTipi;
                turModel.OdenenTutar = item.OdenenTutar;
                model.Add(turModel);
            }

            //List<OtelAdminRezervasyon> turs = _otelAdminRezervasyonService.GetirTumTablolarla().Where(x => x.Durum == true).Where(x => x.BaslangicTarih >= DateTime.Now).ToList();
            //List<OtelAdminRezervasyonListeViewModel> models = new List<OtelAdminRezervasyonListeViewModel>();
            //foreach (var item in turs)
            //{
            //    OtelAdminRezervasyonListeViewModel turModels = new OtelAdminRezervasyonListeViewModel();
            //    turModels.Id = item.Id;
            //    turModels.Telefon = item.Telefon;
            //    turModels.Email = item.Email;
            //    turModels.BaslangicTarih = item.BaslangicTarih;
            //    turModels.BitisTarih = item.BitisTarih;
            //    turModels.Ad = item.Ad;
            //    turModels.Soyad = item.Soyad;
            //    turModels.Tc = item.Tc;
            //    turModels.OtelAd = item.Otels.OtelAd;
            //    turModels.Picture = item.Otels.Picture;
            //    turModels.OdaTipi = item.OtelOdas.OdaTipi;
            //    turModels.OdenecekTutar = item.OdenecekTutar;
            //    models.Add(turModels);
            //}
            //ViewBag.rezervasyon = models;
            return View(model);
        }


    }
}
