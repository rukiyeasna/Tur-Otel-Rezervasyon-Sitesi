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
    public class TurAltKategoriController : Controller
    {
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly UserManager<AppUser> _userManager;
        public TurAltKategoriController(ITurBilgileriService turBilgileriService, UserManager<AppUser> userManager)
        {
            _turBilgileriService = turBilgileriService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string altKategori)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullaniciId = appUser.Id;

            List<TurBilgileri> turBilgileri = _turBilgileriService.GetirHepsi().Where(x => x.TurAltKategori == altKategori).Where(y => y.Durum == true).ToList();
            List<TurBilgiViewModel> modeltur = new List<TurBilgiViewModel>();
            foreach (var item in turBilgileri)
            {
                TurBilgiViewModel turmodel = new TurBilgiViewModel();
                turmodel.TurId = item.TurId;
                turmodel.TurBasligi = item.TurBasligi;
                turmodel.BaslangicTarihi = item.BaslangicTarihi;
                turmodel.BitisTarihi = item.BitisTarihi;
                turmodel.Picture = item.Picture;
                turmodel.Fiyat = item.Fiyat;
                modeltur.Add(turmodel);
            }
            ViewBag.TurAltBaslik = altKategori;
            return View(modeltur);
        }
    }
}
