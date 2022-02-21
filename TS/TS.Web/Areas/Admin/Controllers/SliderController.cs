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
    public class SliderController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ISliderService _sliderService;
        public SliderController(IHostingEnvironment environment, ISliderService sliderService)
        {
            _environment = environment;
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            List<Slider> slider = _sliderService.GetirHepsi().ToList();
            List<SliderViewModel> model = new List<SliderViewModel>();
            foreach (var item in slider)
            {
                SliderViewModel slidermodel = new SliderViewModel();
                slidermodel.Id = item.Id;
                slidermodel.Baslik = item.Baslik;
                slidermodel.Picture = item.Picture;
                model.Add(slidermodel);
            }

            ViewBag.sonuc = model;
            return View(new SliderAddViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SliderAddViewModel model)
        {
            var resimler = Path.Combine(_environment.WebRootPath, "img");
            if (model.ResimDosyasi.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, model.ResimDosyasi.FileName),
                    FileMode.Create))
                {
                    await model.ResimDosyasi.CopyToAsync(fileStream);

                }
            }
            model.Picture = model.ResimDosyasi.FileName;
            if (ModelState.IsValid)
            {
                _sliderService.Kaydet(new Slider
                {
                    Baslik = model.Baslik,                         
                    Picture = model.ResimDosyasi.FileName
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateSlider()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            _sliderService.Sil(new Slider { Id = id});
            //return RedirectToAction("Index");
            return Json(null);
        }

        
    }
}
