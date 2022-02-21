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
    public class OtelSliderController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IOtelService _otelService;
        private readonly IOtelOdaService _otelOdaService;
        private readonly IOtelImageService _otelImageService;
        private readonly IOtelOdaImageService _otelOdaImageService;
        public OtelSliderController(IOtelOdaService otelOdaService, IHostingEnvironment environment, IOtelService otelService, IOtelImageService otelImageService, IOtelOdaImageService otelOdaImageService)
        {
            _environment = environment;
            _otelService = otelService;
            _otelImageService = otelImageService;
            _otelOdaImageService = otelOdaImageService;
            _otelOdaService = otelOdaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OtelListe()
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

        public IActionResult OtelOdaListe()
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

        public IActionResult OtelSliderEkleme(int id)
        {
            List<OtelImage> getir = _otelImageService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            List<OtelSehirListeViewModel> turBilgileris = new List<OtelSehirListeViewModel>();
            foreach (var item in getir)
            {
                OtelSehirListeViewModel turModel = new OtelSehirListeViewModel();
                turModel.Picture = item.Picture;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;

            OtelImageViewModel model = new OtelImageViewModel
            {
                OtelId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> OtelSliderEkleme(OtelImageViewModel model)
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
                _otelImageService.Kaydet(new OtelImage
                {
                    OtelId = model.OtelId,
                    Picture = model.ResimDosyasi.FileName

                });
                //return RedirectToAction("");
            }

            List<OtelImage> getir = _otelImageService.GetirHepsi().Where(x => x.OtelId == model.OtelId).ToList();
            List<OtelSehirListeViewModel> turBilgileris = new List<OtelSehirListeViewModel>();
            foreach (var item in getir)
            {
                OtelSehirListeViewModel turModel = new OtelSehirListeViewModel();
                turModel.Picture = item.Picture;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;
            return View(model);
        }

        public IActionResult OtelOdaSliderEkleme(int id)
        {
            List<OtelOdaImage> getir = _otelOdaImageService.GetirHepsi().Where(x => x.OtelOdaId == id).ToList();
            List<OtelOdaGuncelleViewModel> turBilgileris = new List<OtelOdaGuncelleViewModel>();
            foreach (var item in getir)
            {
                OtelOdaGuncelleViewModel turModel = new OtelOdaGuncelleViewModel();
                turModel.Picture = item.Picture;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;

            OtelOdaImageViewModel model = new OtelOdaImageViewModel
            {
                OtelOdaId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> OtelOdaSliderEkleme(OtelOdaImageViewModel model)
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
                _otelOdaImageService.Kaydet(new OtelOdaImage
                {
                    OtelOdaId = model.OtelOdaId,
                    Picture = model.ResimDosyasi.FileName

                });
                //return RedirectToAction("");
            }

            List<OtelOdaImage> getir = _otelOdaImageService.GetirHepsi().Where(x => x.OtelOdaId == model.OtelOdaId).ToList();
            List<OtelOdaGuncelleViewModel> turBilgileris = new List<OtelOdaGuncelleViewModel>();
            foreach (var item in getir)
            {
                OtelOdaGuncelleViewModel turModel = new OtelOdaGuncelleViewModel();
                turModel.Picture = item.Picture;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;
            return View(model);
        }
    }
}
