using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;
using TS.Web.Areas.Admin.Models;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfilController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMesajService _mesajService;
        public ProfilController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMesajService mesajService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mesajService = mesajService;
        }
        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Surname = appUser.Surname;
            model.Email = appUser.Email;
            model.Username = appUser.UserName;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model)
        {
            var guncellenecekKullanici = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
            if (ModelState.IsValid)
            {
                guncellenecekKullanici.Name = model.Name;
                guncellenecekKullanici.Surname = model.Surname;
                guncellenecekKullanici.Email = model.Email;
                guncellenecekKullanici.UserName = model.Username;

                var result = await _userManager.UpdateAsync(guncellenecekKullanici);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti";
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> ChangePassword()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.Id = appUser.Id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
            if (ModelState.IsValid)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    return RedirectToAction("ChangePassword");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);
        }

        public IActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciEkle(AdminUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    PhoneNumber = model.Phone
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("KullaniciEkle");
                    }
                    foreach (var item in addRoleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Mesajlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;
            var username = appUser.UserName;

            List<Mesaj> mesajs = _mesajService.GetirHepsi().Where(x => x.Alici == username).ToList();
            List<MesajListeViewModel> model = new List<MesajListeViewModel>();
            foreach (var item in mesajs)
            {
                MesajListeViewModel mesajListeViewModel = new MesajListeViewModel();
                mesajListeViewModel.Id = item.Id;
                mesajListeViewModel.Gonderici = item.Gonderici;
                mesajListeViewModel.Konu = item.Konu;
                mesajListeViewModel.Kategori = item.Kategori;
                mesajListeViewModel.Alici = item.Alici;
                mesajListeViewModel.Icerik = item.Icerik;
                mesajListeViewModel.Tarih = item.Tarih;
                model.Add(mesajListeViewModel);
            }

            List<Mesaj> mesajss = _mesajService.GetirHepsi().Where(x => x.Gonderici == username).ToList();
            List<MesajListeViewModel> modell = new List<MesajListeViewModel>();
            foreach (var item in mesajss)
            {
                MesajListeViewModel mesajListeViewModels = new MesajListeViewModel();
                mesajListeViewModels.Id = item.Id;
                mesajListeViewModels.Gonderici = item.Gonderici;
                mesajListeViewModels.Konu = item.Konu;
                mesajListeViewModels.Kategori = item.Kategori;
                mesajListeViewModels.Alici = item.Alici;
                mesajListeViewModels.Icerik = item.Icerik;
                mesajListeViewModels.Tarih = item.Tarih;
                modell.Add(mesajListeViewModels);
            }

            ViewBag.Gonderilen = modell;

            return View(model);
        }

        public IActionResult MesajGonder(string gonderici)
        {
            ViewBag.Alici = gonderici;
            return View(new MesajListeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> MesajGonder(MesajListeViewModel model, string alici)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;
            var username = appUser.UserName;
            if (ModelState.IsValid)
            {
                _mesajService.Kaydet(new Mesaj
                {
                    Alici = alici,
                    Gonderici = username,
                    Icerik = model.Icerik,
                    Tarih = DateTime.Now
                });

                return RedirectToAction("Mesajlarim");
            }
            return View(model);
        }
    }
}
