using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Areas.Admin.Models;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class OtelBilgileriController : Controller
    {
        private readonly IOtelService _otelService;
        private readonly IOtelOdaService _otelOdaService;
        private readonly IHostingEnvironment _environment;
        private readonly IOtelOzellikService _otelOzellikService;
        private readonly IOtelOdaOzellikService _otelOdaOzellikService;
        public OtelBilgileriController(IOtelOdaService otelOdaService, IOtelService otelService, IHostingEnvironment environment, IOtelOzellikService otelOzellikService, IOtelOdaOzellikService otelOdaOzellikService)
        {
            _otelOdaService = otelOdaService;
            _otelService = otelService;
            _environment = environment;
            _otelOzellikService = otelOzellikService;
            _otelOdaOzellikService = otelOdaOzellikService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Oteller()
        {
            List<Otel> otel = _otelService.GetirHepsi().ToList();
            List<OtelListeViewModel> model = new List<OtelListeViewModel>();
            foreach (var item in otel)
            {
                OtelListeViewModel otelModel = new OtelListeViewModel();
                otelModel.OtelId = item.OtelId;
                otelModel.Sehir = item.Sehir;
                otelModel.OtelAd = item.OtelAd;
                otelModel.Picture = item.Picture;
                otelModel.Vize = item.Vize;
                otelModel.Anagrup = item.Anagrup;
                model.Add(otelModel);
            }
            return View(model);
        }

        public IActionResult OtelEkle()
        {
            return View(new OtelListeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> OtelEkle(OtelListeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resimler = Path.Combine(_environment.WebRootPath, "img");
                if (model.ResimDosyasi != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(resimler, model.ResimDosyasi.FileName),
                        FileMode.Create))
                    {
                        await model.ResimDosyasi.CopyToAsync(fileStream);

                    }
                }
                model.Picture = model.ResimDosyasi.FileName;

                _otelService.Kaydet(new Otel
                {
                    OtelId = model.OtelId,
                    Sehir = model.Sehir,
                    OtelAd = model.OtelAd,
                    Picture = model.ResimDosyasi.FileName,
                    OtelOzellik = model.OtelOzellik,
                    Vize = model.Vize,
                    Anagrup = model.Anagrup
                });

                return RedirectToAction("Oteller");
            }
            return View(model);
        }

        public IActionResult OtelGuncelle(int id)
        {
            var otel = _otelService.GetirIdile(id);
            OtelGüncelleViewModel model = new OtelGüncelleViewModel
            {
                OtelId = otel.OtelId,
                Sehir = otel.Sehir,
                OtelAd = otel.OtelAd,
                Picture = otel.Picture,
                OtelOzellik = otel.OtelOzellik,
                Vize = otel.Vize,
                Anagrup = otel.Anagrup
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult OtelGuncelle(OtelGüncelleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecektur = _otelService.GetirIdile(model.OtelId);
                if (model.ResimDosyasi != null)
                {
                    var uzanti = Path.GetExtension(model.ResimDosyasi.FileName);
                    var yeniresimad = Guid.NewGuid() + uzanti;
                    var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniresimad);
                    var stream = new FileStream(yuklenecekyer, FileMode.Create);
                    model.ResimDosyasi.CopyTo(stream);

                    guncellenecektur.Picture = yeniresimad;
                }
                guncellenecektur.OtelId = model.OtelId;
                guncellenecektur.Sehir = model.Sehir;
                guncellenecektur.OtelAd = model.OtelAd;
                guncellenecektur.OtelOzellik = model.OtelOzellik;
                guncellenecektur.Vize = model.Vize;
                guncellenecektur.Anagrup = model.Anagrup;
                _otelService.Guncelle(guncellenecektur);
                return RedirectToAction("Oteller");
            }
            return View(model);
        }
        public IActionResult OtelSil(int id)
        {
            var tur = _otelService.GetirIdile(id);
            OtelGüncelleViewModel model = new OtelGüncelleViewModel
            {
                OtelId = tur.OtelId,
                OtelAd = tur.OtelAd,
                Sehir = tur.Sehir,
                Picture = tur.Picture,
                OtelOzellik = tur.OtelOzellik,
                Vize = tur.Vize,
                Anagrup = tur.Anagrup
            };
            return View(model);


        }

        [HttpPost]
        public IActionResult OtelSilme(int id)
        {
            _otelService.Sil(new Otel { OtelId = id });
            return RedirectToAction("Oteller");
        }

        public IActionResult OdaEkle(int id)
        {
            ViewBag.OtelId = id;
            return View(new OtelOdaViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> OdaEkle(OtelOdaViewModel model)
        {
            if (model.GirisTarihi > model.CikisTarihi)
            {
                ViewBag.deger = 0;
                ViewBag.metin = "Giriş tarihi çıkış tarihinden sonra olamaz.";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var resimler = Path.Combine(_environment.WebRootPath, "img");
                    if (model.ResimDosyasi != null)
                    {
                        using (var fileStream = new FileStream(Path.Combine(resimler, model.ResimDosyasi.FileName),
                            FileMode.Create))
                        {
                            await model.ResimDosyasi.CopyToAsync(fileStream);

                        }
                    }
                    model.Picture = model.ResimDosyasi.FileName;

                    _otelOdaService.Kaydet(new OtelOda
                    {
                        //Id = model.Id,
                        OtelId = model.OtelId,
                        OdaTipi = model.OdaTipi,
                        IcerikBilgisi = model.IcerikBilgisi,
                        Picture = model.ResimDosyasi.FileName,
                        GirisTarihi = model.GirisTarihi,
                        CikisTarihi = model.CikisTarihi,
                        Bilgi = model.Bilgi,
                        Fiyat = model.Fiyat,
                        OtelOdaOzellik = model.OtelOdaOzellik,
                        ParaBirimi = model.ParaBirimi
                    });

                    return RedirectToAction("Oteller");
                }
            }
            return View(model);
        }

        public IActionResult OtelSehir()
        {
            List<SehirViewModel> modelsehir = new List<SehirViewModel>();
            ViewModel model = new ViewModel();
            var list = _otelService.GetirHepsi().ToList();
            var sehirgrup = from sehir in list
                            group sehir by new { sehir.Sehir } into g
                            select new
                            {
                                Sehir = g.Key.Sehir,
                            };

            foreach (var resultg in sehirgrup)
            {
                SehirViewModel deneme = new SehirViewModel();
                deneme.Sehir = resultg.Sehir;
                modelsehir.Add(deneme);
            }
            model.SehirViewModel = modelsehir;
            return View(model);
        }

        public IActionResult SehirOtelGetir(string sehir)
        {
            List<Otel> otel = _otelService.GetirHepsi().Where(x => x.Sehir == sehir).ToList();
            List<OtelSehirListeViewModel> model = new List<OtelSehirListeViewModel>();
            foreach (var item in otel)
            {
                OtelSehirListeViewModel otelmodel = new OtelSehirListeViewModel();
                otelmodel.OtelId = item.OtelId;
                otelmodel.Sehir = item.Sehir;
                otelmodel.OtelAd = item.OtelAd;
                otelmodel.Picture = item.Picture;
                model.Add(otelmodel);

            }
            return View(model);
        }

        public IActionResult SehirOdaGetir(int id, string? oteladi)
        {
            ViewBag.Otelad = oteladi;
            ViewBag.otel = id;

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
                model.Add(otelmodel);

            }
            return View(model);
        }

        public IActionResult OtelOdaGuncelle(int id)
        {
            var otel = _otelOdaService.GetirIdile(id);
            OtelOdaGuncelleViewModel model = new OtelOdaGuncelleViewModel
            {
                OtelId = otel.OtelId,
                Id = otel.Id,
                OdaTipi = otel.OdaTipi,
                IcerikBilgisi = otel.IcerikBilgisi,
                GirisTarihi = otel.GirisTarihi,
                CikisTarihi = otel.CikisTarihi,
                Bilgi = otel.Bilgi,
                Fiyat = otel.Fiyat,
                Picture = otel.Picture,
                OtelOdaOzellik = otel.OtelOdaOzellik,
                ParaBirimi = otel.ParaBirimi,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult OtelOdaGuncelle(OtelOdaGuncelleViewModel model)
        {
            if (model.GirisTarihi > model.CikisTarihi)
            {
                ViewBag.deger = 0;
                ViewBag.metin = "Giriş tarihi çıkış tarihinden sonra olamaz.";
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var guncellenecekoda = _otelOdaService.GetirIdile(model.Id);
                    if (model.ResimDosyasi != null)
                    {
                        var uzanti = Path.GetExtension(model.ResimDosyasi.FileName);
                        var yeniresimad = Guid.NewGuid() + uzanti;
                        var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniresimad);
                        var stream = new FileStream(yuklenecekyer, FileMode.Create);
                        model.ResimDosyasi.CopyTo(stream);

                        guncellenecekoda.Picture = yeniresimad;
                    }

                    guncellenecekoda.OtelId = model.OtelId;
                    guncellenecekoda.Id = model.Id;
                    guncellenecekoda.OdaTipi = model.OdaTipi;
                    guncellenecekoda.IcerikBilgisi = model.IcerikBilgisi;
                    guncellenecekoda.GirisTarihi = model.GirisTarihi;
                    guncellenecekoda.CikisTarihi = model.CikisTarihi;
                    guncellenecekoda.Bilgi = model.Bilgi;
                    guncellenecekoda.Fiyat = model.Fiyat;
                    guncellenecekoda.Picture = model.Picture;
                    guncellenecekoda.OtelOdaOzellik = model.OtelOdaOzellik;
                    guncellenecekoda.ParaBirimi = model.ParaBirimi;
                    _otelOdaService.Guncelle(guncellenecekoda);
                    return RedirectToAction("OtelSehir");
                }
            }
            return View(model);
        }

        public IActionResult OtelOdaSil(int id)
        {
            var otel = _otelOdaService.GetirIdile(id);
            OtelOdaGuncelleViewModel model = new OtelOdaGuncelleViewModel
            {
                OtelId = otel.OtelId,
                Id = otel.Id,
                OdaTipi = otel.OdaTipi,
                IcerikBilgisi = otel.IcerikBilgisi,
                GirisTarihi = otel.GirisTarihi,
                CikisTarihi = otel.CikisTarihi,
                Bilgi = otel.Bilgi,
                Fiyat = otel.Fiyat,
                Picture = otel.Picture,
                OtelOdaOzellik = otel.OtelOdaOzellik,
                ParaBirimi = otel.ParaBirimi,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult OtelOdaSilme(int id)
        {
            _otelOdaService.Sil(new OtelOda { Id = id });
            return RedirectToAction("OtelSehir");
        }

        public IActionResult OtelOzellik()
        {
            List<Otel> otel = _otelService.GetirHepsi().ToList();
            List<OtelListeViewModel> model = new List<OtelListeViewModel>();
            foreach (var item in otel)
            {
                OtelListeViewModel otelModel = new OtelListeViewModel();
                otelModel.OtelId = item.OtelId;
                otelModel.Sehir = item.Sehir;
                otelModel.OtelAd = item.OtelAd;
                otelModel.Picture = item.Picture;
                model.Add(otelModel);
            }
            return View(model);
        }

        public IActionResult OtelOzellikEkle(int id)
        {
            List<OtelOzellik> getir = _otelOzellikService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            List<OtelOzellikListeViewModel> turBilgileris = new List<OtelOzellikListeViewModel>();
            foreach (var item in getir)
            {
                OtelOzellikListeViewModel turModel = new OtelOzellikListeViewModel();
                turModel.Ozellik = item.Ozellik;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;

            OtelOzellikViewModel model = new OtelOzellikViewModel
            {
                OtelId = id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult OtelOzellikEkle(OtelOzellikViewModel model)
        {
            if (ModelState.IsValid)
            {
                _otelOzellikService.Kaydet(new OtelOzellik
                {
                    OtelId = model.OtelId,
                    Ozellik = model.Ozellik
                });
            }
            List<OtelOzellik> getir = _otelOzellikService.GetirHepsi().Where(x => x.OtelId == model.OtelId).ToList();
            List<OtelOzellikListeViewModel> turBilgileris = new List<OtelOzellikListeViewModel>();
            foreach (var item in getir)
            {
                OtelOzellikListeViewModel turModel = new OtelOzellikListeViewModel();
                turModel.Ozellik = item.Ozellik;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;
            return View(model);

        }

        public IActionResult OtelOdaOzellik()
        {
            List<OtelOda> otel = _otelOdaService.GetirOtelBilgileri().ToList();
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
                model.Add(otelmodel);

            }
            return View(model);
        }

        public IActionResult OtelOdaOzellikEkle(int id)
        {
            List<OtelOdaOzellik> getir = _otelOdaOzellikService.GetirHepsi().Where(x => x.OtelOdaId == id).ToList();
            List<OtelOdaOzellikViewModel> turBilgileris = new List<OtelOdaOzellikViewModel>();
            foreach (var item in getir)
            {
                OtelOdaOzellikViewModel turModel = new OtelOdaOzellikViewModel();
                turModel.Ozellik = item.Ozellik;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;

            OtelOdaOzellikViewModel model = new OtelOdaOzellikViewModel
            {
                OtelOdaId = id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult OtelOdaOzellikEkle(OtelOdaOzellikViewModel model)
        {
            if (ModelState.IsValid)
            {
                _otelOdaOzellikService.Kaydet(new OtelOdaOzellik
                {
                    OtelOdaId = model.OtelOdaId,
                    Ozellik = model.Ozellik
                });
            }
            List<OtelOdaOzellik> getir = _otelOdaOzellikService.GetirHepsi().Where(x => x.OtelOdaId == model.OtelOdaId).ToList();
            List<OtelOdaOzellikViewModel> turBilgileris = new List<OtelOdaOzellikViewModel>();
            foreach (var item in getir)
            {
                OtelOdaOzellikViewModel turModel = new OtelOdaOzellikViewModel();
                turModel.Ozellik = item.Ozellik;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;
            return View(model);
        }

    }
}
