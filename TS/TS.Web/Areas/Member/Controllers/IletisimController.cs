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
    public class IletisimController : Controller
    {
        private readonly IMesajService _mesajService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOtelPuanService _otelPuanService;
        private readonly IOtelService _otelService;

        public IletisimController(IMesajService mesajService, UserManager<AppUser> userManager, IOtelPuanService otelPuanService, IOtelService otelService)
        {
            _mesajService = mesajService;
            _userManager = userManager;
            _otelPuanService = otelPuanService;
            _otelService = otelService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Mesajlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;
            var username = appUser.UserName;

            List<Mesaj> mesajs = _mesajService.GetirHepsi().Where(x => x.Gonderici == username).ToList();
            List<MesajMemberViewModel> model = new List<MesajMemberViewModel>();
            foreach (var item in mesajs)
            {
                MesajMemberViewModel mesajListeViewModel = new MesajMemberViewModel();
                mesajListeViewModel.Id = item.Id;
                mesajListeViewModel.Gonderici = item.Gonderici;
                mesajListeViewModel.Konu = item.Konu;
                mesajListeViewModel.Kategori = item.Kategori;
                mesajListeViewModel.Alici = item.Alici;
                mesajListeViewModel.Icerik = item.Icerik;
                mesajListeViewModel.Tarih = item.Tarih;
                model.Add(mesajListeViewModel);
            }

            ViewBag.Mesaj = model;
            ViewBag.Sayim = model.Count();
            return View(new MesajMemberViewModel());
        }
        public async Task<IActionResult> MesajlarimGelen()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;
            var username = appUser.UserName;
            ViewBag.Gonderici = username;
            List<Mesaj> mesajs = _mesajService.GetirHepsi().Where(x => x.Alici == username).ToList();
            List<MesajMemberViewModel> model = new List<MesajMemberViewModel>();
            foreach (var item in mesajs)
            {
                MesajMemberViewModel mesajListeViewModel = new MesajMemberViewModel();
                mesajListeViewModel.Id = item.Id;
                mesajListeViewModel.Gonderici = item.Gonderici;
                mesajListeViewModel.Konu = item.Konu;
                mesajListeViewModel.Kategori = item.Kategori;
                mesajListeViewModel.Alici = item.Alici;
                mesajListeViewModel.Icerik = item.Icerik;
                mesajListeViewModel.Tarih = item.Tarih;
                model.Add(mesajListeViewModel);
            }
            ViewBag.Gelen = model;
            ViewBag.Sayim = model.Count();
            return View(new MesajMemberViewModel());
        }
        //public async Task<IActionResult> MesajGonder()
        //{
        //    var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        //    ViewBag.KullanıId = appUser.Id;
        //    var username = appUser.UserName;

        //    return View(new MesajMemberViewModel());
        //}

        [HttpPost]
        public async Task<IActionResult> MesajGonder(MesajMemberViewModel model)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;
            var username = appUser.UserName;
            if (ModelState.IsValid)
            {
                _mesajService.Kaydet(new Mesaj
                {
                    Alici = "rukiye",
                    Gonderici = username,
                    Icerik = model.Icerik,
                    Konu = model.Konu,
                    Kategori = model.Kategori,
                    Tarih = DateTime.Now
                });

                return RedirectToAction("Mesajlarim");
            }
            return View(model);
        }
        public async Task<IActionResult> Yorumlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var id = appUser.Id;
            List<OtelPuan> mesajs = _otelPuanService.GetirHepsi().Where(x => x.AppUserId == id).ToList();
            List<OtelPuanViewModel> model = new List<OtelPuanViewModel>();
            foreach (var item in mesajs)
            {
                OtelPuanViewModel mesajListeViewModel = new OtelPuanViewModel();
                mesajListeViewModel.OtelPuanId = item.Id;
                mesajListeViewModel.Yorum = item.Yorum;
                mesajListeViewModel.OtelId = item.OtelId;
                mesajListeViewModel.FiyatDeger = item.FiyatDeger;
                mesajListeViewModel.HizmetDeger = item.HizmetDeger;
                mesajListeViewModel.YiyecekDeger = item.YiyecekDeger;
                mesajListeViewModel.HizmetDeger = item.HizmetDeger;
                mesajListeViewModel.TemizDeger = item.TemizDeger;
                mesajListeViewModel.PersonelDeger = item.PersonelDeger;
                mesajListeViewModel.OdaDeger = item.OdaDeger;
                model.Add(mesajListeViewModel);
            }
            List<Otel> otels = _otelService.GetirHepsi().ToList();
            ViewBag.Otel = otels;

            ViewBag.Sayim = model.Count();
            return View(model);
        }
        public IActionResult Guncelle(int id)
        {
            var puan = _otelPuanService.GetirIdile(id);
            OtelPuanViewModel model = new OtelPuanViewModel
            {
                FiyatDeger = puan.FiyatDeger,
                HizmetDeger = puan.HizmetDeger,
                PersonelDeger = puan.PersonelDeger,
                OdaDeger = puan.OdaDeger,
                TemizDeger = puan.TemizDeger,
                Yorum = puan.Yorum,
                AppUserId = puan.AppUserId,
                OtelId = puan.OtelId,
                YiyecekDeger = puan.YiyecekDeger,
                Username = puan.Username,
                OtelPuanId = puan.Id

            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Guncelle(OtelPuanViewModel model)
        {
            if (ModelState.IsValid)
            {
                _otelPuanService.Guncelle(new OtelPuan
                {
                    Id = model.OtelPuanId,
                    OtelId = model.OtelId,
                    AppUserId = model.AppUserId,
                    FiyatDeger = model.FiyatDeger,
                    HizmetDeger = model.HizmetDeger,
                    PersonelDeger = model.PersonelDeger,
                    OdaDeger = model.OdaDeger,
                    YiyecekDeger = model.YiyecekDeger,
                    TemizDeger = model.TemizDeger,
                    Yorum = model.Yorum,
                    Username = model.Username
                });
                return RedirectToAction("Yorumlarim");

            }
            return View(model);
        }
    }
}
