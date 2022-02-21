using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GorevController : Controller
    {
        private readonly ITurBilgileriService _turBilgileriService;
        public GorevController(ITurBilgileriService turBilgileriService )
        {
            _turBilgileriService = turBilgileriService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SilGorev(int id)
        {
            _turBilgileriService.Sil(new TurBilgileri { TurId = id });
            return Json(null);
        }
    }
}
