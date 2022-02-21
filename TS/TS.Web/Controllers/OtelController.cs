using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Models;

namespace TS.Web.Controllers
{
    public class OtelController : Controller
    {
        private readonly IOtelService _otelService;
        private readonly IOtelOdaService _otelOdaService;
        private readonly IOtelImageService _otelImageService;
        private readonly IOtelOdaImageService _otelOdaImageService;
        public OtelController(IOtelOdaService otelOdaService, IOtelService otelService, IOtelImageService otelImageService, IOtelOdaImageService otelOdaImageService)
        {
            _otelService = otelService;
            _otelImageService = otelImageService;
            _otelOdaImageService = otelOdaImageService;
            _otelOdaService = otelOdaService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SehirOtel(string sehir)
        {
            List<Otel> otel = _otelService.GetirHepsi().Where(x => x.Sehir == sehir).ToList();
            List<OtelListeListViewModel> modelotel = new List<OtelListeListViewModel>();
            foreach (var item in otel)
            {
                OtelListeListViewModel otelmodel = new OtelListeListViewModel();
                otelmodel.OtelAd = item.OtelAd;
                otelmodel.OtelId = item.OtelId;
                otelmodel.Sehir = item.Sehir;
                otelmodel.Picture = item.Picture;
                modelotel.Add(otelmodel);
            }
            ViewBag.OtelSehri = sehir;
            return View(modelotel);
        }

        public IActionResult OtelBilgileri(int id, string? otelad)
        {
            List<OtelImage> images = _otelImageService.GetirHepsi().Where(x => x.OtelId == id).ToList();
            List<OtelImageListViewModel> imageModel = new List<OtelImageListViewModel>();
            foreach (var item in images)
            {
                OtelImageListViewModel imagesViewModel = new OtelImageListViewModel();
                imagesViewModel.Id = item.Id;
                imagesViewModel.OtelId = item.OtelId;
                imagesViewModel.Picture = item.Picture;
                imageModel.Add(imagesViewModel);

            }
            ViewBag.Image = imageModel;
            ViewBag.sayi = images.Count();
            ViewBag.Otelad = otelad;

            List<OtelOda> otel = _otelOdaService.GetirOtelBilgileri().Where(x => x.OtelId == id).ToList();
            List<OtelOdaListViewModel> model = new List<OtelOdaListViewModel>();
            foreach (var item in otel)
            {
                OtelOdaListViewModel otelmodel = new OtelOdaListViewModel();
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

            return View(model);

        }

        public IActionResult OtelOdaBilgileri(int id, string? otelad)
        {
            List<OtelOdaImage> images = _otelOdaImageService.GetirHepsi().Where(x => x.OtelOdaId == id).ToList();
            List<OtelOdaImageListViewModel> imageModel = new List<OtelOdaImageListViewModel>();
            foreach (var item in images)
            {
                OtelOdaImageListViewModel imagesViewModel = new OtelOdaImageListViewModel();
                imagesViewModel.Id = item.Id;
                //imagesViewModel.OtelId = item.OtelId;
                imagesViewModel.Picture = item.Picture;
                imageModel.Add(imagesViewModel);

            }
            ViewBag.Image = imageModel;
            ViewBag.sayi = images.Count();
            ViewBag.Otelad = otelad;
            List<OtelOda> otel = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == id).ToList();
            List<OtelOdaListViewModel> model = new List<OtelOdaListViewModel>();
            foreach (var item in otel)
            {
                OtelOdaListViewModel otelmodel = new OtelOdaListViewModel();
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

                ViewBag.OdaTipi = item.OdaTipi;
                ViewBag.Ozellik = item.OtelOdaOzellik;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Arama(string sehir, DateTime baslangic, DateTime bitis)
        {
            ViewBag.baslangic = baslangic;
            ViewBag.bitis = bitis;
            ViewBag.kategori = sehir;

            List<OtelOda> OtelBilgileri;
            List<OtelOdaListViewModel> model = new List<OtelOdaListViewModel>();

            if (sehir != "null" && baslangic != null && bitis != null)
            {
                OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.GirisTarihi >= baslangic).Where(x => x.CikisTarihi <= bitis).Where(x => x.Otels.Sehir == sehir).ToList();
                foreach (var item in OtelBilgileri)
                {
                    OtelOdaListViewModel otelmodel = new OtelOdaListViewModel();
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
                    OtelOdaListViewModel otelmodel = new OtelOdaListViewModel();
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

        

    }
}
