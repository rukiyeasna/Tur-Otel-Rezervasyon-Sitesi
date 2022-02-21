using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Areas.Admin.Models;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly IImagesService _imagesService;
        public ImageController(ITurBilgileriService turBilgileriService, IImagesService imagesService, IHostingEnvironment environment)
        {
            _turBilgileriService = turBilgileriService;
            _imagesService = imagesService;
            _environment = environment;
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
        public IActionResult SliderEkleme(int TurId)
        {
            List<Images> getir = _imagesService.GetirHepsi().Where(x => x.TurId == TurId).ToList();
            List<TurListViewModel> turBilgileris = new List<TurListViewModel>();
            foreach (var item in getir)
            {
                TurListViewModel turModel = new TurListViewModel();
                turModel.Picture = item.Picture;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;

            ImageViewModel model = new ImageViewModel
            {
                TurId = TurId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SliderEkleme(ImageViewModel model)
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
                _imagesService.Kaydet(new Images
                {
                    TurId = model.TurId,
                    Picture = model.ResimDosyasi.FileName

                });
                //return RedirectToAction("");
            }

            List<Images> getir = _imagesService.GetirHepsi().Where(x => x.TurId == model.TurId).ToList();
            List<TurListViewModel> turBilgileris = new List<TurListViewModel>();
            foreach (var item in getir)
            {
                TurListViewModel turModel = new TurListViewModel();
                turModel.Picture = item.Picture;
                turBilgileris.Add(turModel);
            }

            ViewBag.Gorsel = turBilgileris;
            return View(model);
        }
    }
}
