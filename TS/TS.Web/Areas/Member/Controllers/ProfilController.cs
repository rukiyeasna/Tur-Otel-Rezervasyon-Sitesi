using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TS.Entities.Concrete;
using TS.Web.Areas.Member.Models;

namespace TS.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class ProfilController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ProfilController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserViewModel model = new AppUserViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Surname = appUser.Surname;
            model.Email = appUser.Email;
            model.Username = appUser.UserName;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(AppUserViewModel model)
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

                //foreach (var item in result.Errors)
                //{
                //    ModelState.AddModelError("", item.Description);
                //}
            }
            return View(model);
        }

        public async Task<IActionResult> ChangePassword()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ChangePassViewModel model = new ChangePassViewModel();
            model.Id = appUser.Id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassViewModel model)
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
    }
}
