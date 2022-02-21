using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TS.Business.Interfaces;
using TS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TS.Entities.Concrete;
using TS.Web.Areas.Admin.Models;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly IOtelBilgileriService _otelBilgileriService;
        TsContext context = new TsContext();
        public HomeController(IHostingEnvironment environment, ITurBilgileriService turBilgileriService, IOtelBilgileriService otelBilgileriService)
        {
            _environment = environment;
            _turBilgileriService = turBilgileriService;
            _otelBilgileriService = otelBilgileriService;
        }
        public IActionResult Index()
        {
            List<TurBilgileri> tur = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).ToList();
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
                model.Add(turModel);
            }
            return View(model);
        }

        public IActionResult Detaylar(int id)
        {
            TempData["Active"] = "turguncelle";
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
                Anagrup=tur.Anagrup,
                ParaBirimi=tur.ParaBirimi

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Detaylar(TurListViewModel model)
        {
            if (model.BaslangicTarihi > model.BitisTarihi)
            {
                ViewBag.deger = 0;
                ViewBag.metin = "Başlangıç tarihi bitiş tarihinden sonra olamaz.";
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var guncellenecektur = _turBilgileriService.GetirIdile(model.TurId);
                    if (model.ResimDosyasi != null)
                    {
                        var uzanti = Path.GetExtension(model.ResimDosyasi.FileName);
                        var yeniresimad = Guid.NewGuid() + uzanti;
                        var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniresimad);
                        var stream = new FileStream(yuklenecekyer, FileMode.Create);
                        model.ResimDosyasi.CopyTo(stream);

                        guncellenecektur.Picture = yeniresimad;
                    }
                    guncellenecektur.TurId = model.TurId;
                    guncellenecektur.TurAltKategori = model.TurAltKategori;
                    guncellenecektur.BaslangicTarihi = model.BaslangicTarihi;
                    guncellenecektur.BitisTarihi = model.BitisTarihi;
                    guncellenecektur.Fiyat = model.Fiyat;
                    guncellenecektur.GidilecekYerler = model.GidilecekYerler;
                    guncellenecektur.TurBasligi = model.TurBasligi;
                    guncellenecektur.FiyataDahilHizmetler = model.FiyataDahilHizmetler;
                    guncellenecektur.FiyataDahilOlmayanHizmetler = model.FiyataDahilOlmayanHizmetler;
                    guncellenecektur.TurProgrami = model.TurProgrami;
                    guncellenecektur.TurKalkisNoktalari = model.TurKalkisNoktalari;
                    guncellenecektur.Aciklama = model.Aciklama;
                    guncellenecektur.Durum = true;
                    guncellenecektur.Ulasim = model.Ulasim;
                    guncellenecektur.PopulerDurum = model.PopulerDurum;
                    guncellenecektur.Anagrup = model.Anagrup;
                    guncellenecektur.ParaBirimi = model.ParaBirimi;
                    _turBilgileriService.Guncelle(guncellenecektur);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public IActionResult TurEkle()
        {
            TempData["Active"] = "turekle";
            return View(new TurEkleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> TurEkle(TurEkleViewModel model)
        {
            if (model.BaslangicTarihi > model.BitisTarihi)
            {
                ViewBag.deger = 0;
                ViewBag.metin = "Başlangıç tarihi bitiş tarihinden sonra olamaz.";
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

                    _turBilgileriService.Kaydet(new TurBilgileri
                    {
                        TurAltKategori = model.TurAltKategori,
                        BaslangicTarihi = model.BaslangicTarihi,
                        BitisTarihi = model.BitisTarihi,
                        Fiyat = model.Fiyat,
                        GidilecekYerler = model.GidilecekYerler,
                        TurBasligi = model.TurBasligi,
                        FiyataDahilHizmetler = model.FiyataDahilHizmetler,
                        FiyataDahilOlmayanHizmetler = model.FiyataDahilOlmayanHizmetler,
                        TurProgrami = model.TurProgrami,
                        TurKalkisNoktalari = model.TurKalkisNoktalari,
                        Aciklama = model.Aciklama,
                        Durum = true,
                        PopulerDurum = false,
                        Picture = model.ResimDosyasi.FileName,
                        Ulasim = model.Ulasim,
                        Anagrup = model.Anagrup,
                        ParaBirimi=model.ParaBirimi,
                    });

                    return RedirectToAction("Index");
                }
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
                Ulasim = tur.Ulasim,
                Anagrup = tur.Anagrup,
                ParaBirimi=tur.ParaBirimi

            };
            return View(model);
        }

        public IActionResult TurKaldir(int id)
        {
            var getir = _turBilgileriService.GetirIdile(id);
            getir.Durum = false;
            _turBilgileriService.Guncelle(getir);
            return RedirectToAction("Index");
        }

        public IActionResult AddOtelBilgi()
        {

            ViewBag.Tur = new SelectList(_turBilgileriService.GetirHepsi().Where(x => x.Durum == true), "TurId", "TurBasligi");
            return View(new OtelEkleViewModel());
        }

        [HttpPost]
        public IActionResult AddOtelBilgi(OtelEkleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _otelBilgileriService.Kaydet(new OtelBilgileri
                {
                    TurId = model.TurId,
                    OtelBilgiId = model.OtelBilgiId,
                    CiftKisilikOda = model.CiftKisilikOda,
                    TekKisilikOda = model.TekKisilikOda,
                    IlaveYatak = model.IlaveYatak,
                    Cocuk_3_6_Yas = model.Cocuk_3_6_Yas,
                    Cocuk_7_12_Yas = model.Cocuk_7_12_Yas,
                    Aciklama = model.Aciklama,
                    FiyatTanimi = model.FiyatTanimi

                });
                return RedirectToAction("AddOtelBilgi", "Home");
            }
            ViewBag.Tur = new SelectList(_turBilgileriService.GetirHepsi().Where(x => x.Durum == true), "TurId", "TurBasligi");
            return View(model);
        }

        public IActionResult OtelDetay(int id)
        {
            //ViewBag.Tur = new SelectList(_turBilgileriService.GetirHepsi().Where(x => x.Durum == true), "TurId", "TurBasligi");
            List<OtelBilgileri> otel = _otelBilgileriService.GetirHepsi().Where(x => x.TurId == id).ToList();
            ViewBag.Sayi = otel.Count();
            return View(otel);
        }

        public IActionResult OtelGuncelle(int id)
        {
            var otel = _otelBilgileriService.GetirIdile(id);
            OtelListViewModel model = new OtelListViewModel
            {
                TurId = otel.TurId,
                OtelBilgiId = otel.OtelBilgiId,
                FiyatTanimi = otel.FiyatTanimi,
                CiftKisilikOda = otel.CiftKisilikOda,
                TekKisilikOda = otel.CiftKisilikOda,
                IlaveYatak = otel.IlaveYatak,
                Cocuk_3_6_Yas = otel.Cocuk_3_6_Yas,
                Cocuk_7_12_Yas = otel.Cocuk_7_12_Yas
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult OtelGuncelle(OtelListViewModel model)
        {
            if (ModelState.IsValid)
            {
                _otelBilgileriService.Guncelle(new OtelBilgileri
                {
                    TurId = model.TurId,
                    OtelBilgiId = model.OtelBilgiId,
                    FiyatTanimi = model.FiyatTanimi,
                    CiftKisilikOda = model.CiftKisilikOda,
                    TekKisilikOda = model.TekKisilikOda,
                    IlaveYatak = model.IlaveYatak,
                    Cocuk_3_6_Yas = model.Cocuk_3_6_Yas,
                    Cocuk_7_12_Yas = model.Cocuk_7_12_Yas
                });
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public IActionResult OtelSil(int id)
        {
            _otelBilgileriService.Sil(new OtelBilgileri { OtelBilgiId = id });
            return RedirectToAction("Index");
        }
        public IActionResult TurOzellik()
        {
            List<TurBilgileri> tur = _turBilgileriService.GetirHepsi().Where(x => x.Durum == true).ToList();
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
                model.Add(turModel);
            }
            return View(model);
        }
    }
}
