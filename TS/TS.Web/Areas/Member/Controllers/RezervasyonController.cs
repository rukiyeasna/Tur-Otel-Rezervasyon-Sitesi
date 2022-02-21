using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;
using TS.Web.Models;
using TS.Entities.Concrete;
using TS.Web.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using TS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using IyzipayCore.Request;
using IyzipayCore.Model;
using IyzipayCore;

namespace TS.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class RezervasyonController : Controller
    {
        private readonly IOtelBilgileriService _otelBilgileriService;
        private readonly ITurBilgileriService _turBilgileriService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRezervasyonService _rezervasyonService;
        TsContext _db = new TsContext();
        public RezervasyonController(IOtelBilgileriService otelBilgileriService, ITurBilgileriService turBilgileriService, UserManager<AppUser> userManager, IRezervasyonService rezervasyonService)
        {
            _otelBilgileriService = otelBilgileriService;
            _turBilgileriService = turBilgileriService;
            _userManager = userManager;
            _rezervasyonService = rezervasyonService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int yetiskin, int cocuk, int TurId, int id)
        {
            ViewBag.otelid = id;
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;
            ViewBag.Telefon = appUser.PhoneNumber;
            ViewBag.Email = appUser.Email;
            ViewBag.TurId = TurId;

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == id).ToList();
            List<OtelViewModel> ModelOtel = new List<OtelViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelViewModel Otelmodel = new OtelViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                Otelmodel.Picture = item.TurBilgileris.Picture;
                Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
                Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = yetiskin * item.CiftKisilikOda + cocuk * item.Cocuk_3_6_Yas;
                ViewBag.bas = item.TurBilgileris.BaslangicTarihi;
                ViewBag.bit = item.TurBilgileris.BitisTarihi;
            }
            ViewBag.Yetiskin = yetiskin;
            ViewBag.Cocuk = cocuk;
            ViewBag.OtelBilgi = ModelOtel;

            return View(new RezervasyonOdemeViewModel());
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(DateTime baslangic, DateTime bitis, RezervasyonViewModel model, int yetiskin, int cocuk, int id, int kullaniciid, int TurId, double odenen)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _rezervasyonService.Kaydet(new Rezervasyon
        //        {
        //            Id = model.RezervasyonId,
        //            TurId = TurId,
        //            Yad = model.Yad,
        //            Ysoyad = model.Ysoyad,
        //            Ycinsiyet = model.Ycinsiyet,
        //            Ytc = model.Ytc,
        //            Telefon = model.Telefon,
        //            Email = model.Email,
        //            Durum = true,
        //            OtelId = id,
        //            CocukSayisi = cocuk,
        //            YetiskinSayisi = yetiskin,
        //            Tarih = DateTime.Now,
        //            AppUserId = kullaniciid,
        //            OdenenTutar = odenen,
        //            Baslangic = baslangic,
        //            Bitis = bitis
        //        });

        //        return RedirectToAction("Rezervasyonlarim");
        //    }

        //    List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == id).ToList();
        //    List<OtelViewModel> ModelOtel = new List<OtelViewModel>();
        //    foreach (var item in OtelBilgileri)
        //    {
        //        OtelViewModel Otelmodel = new OtelViewModel();
        //        Otelmodel.OtelBilgiId = item.OtelBilgiId;
        //        Otelmodel.TurId = item.TurId;
        //        Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
        //        Otelmodel.IlaveYatak = item.IlaveYatak;
        //        Otelmodel.TekKisilikOda = item.TekKisilikOda;
        //        Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
        //        Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
        //        Otelmodel.Aciklama = item.Aciklama;
        //        Otelmodel.FiyatTanimi = item.FiyatTanimi;
        //        Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
        //        Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
        //        Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
        //        Otelmodel.Picture = item.TurBilgileris.Picture;
        //        Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
        //        Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
        //        ModelOtel.Add(Otelmodel);
        //        ViewBag.Odenecektutar = yetiskin * item.CiftKisilikOda + cocuk * item.Cocuk_3_6_Yas;
        //    }
        //    var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        //    ViewBag.Yetiskin = yetiskin;
        //    ViewBag.Cocuk = cocuk;
        //    ViewBag.OtelBilgi = ModelOtel;
        //    ViewBag.otelid = id;
        //    ViewBag.TurId = TurId;
        //    ViewBag.KullanıId = appUser.Id;
        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Index(DateTime baslangic, DateTime bitis, RezervasyonOdemeViewModel model, int yetiskin, int cocuk, int id, int kullaniciid, int TurId, double odenen)
        {
            if (ModelState.IsValid)
            {
                var payment = PaymentProcess(model);
                if (payment.Status == "success")
                {
                    _rezervasyonService.Kaydet(new Rezervasyon
                    {
                        Id = model.RezervasyonId,
                        TurId = TurId,
                        Yad = model.Yad,
                        Ysoyad = model.Ysoyad,
                        Ycinsiyet = model.Ycinsiyet,
                        Ytc = model.Ytc,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        Durum = true,
                        OtelId = id,
                        CocukSayisi = cocuk,
                        YetiskinSayisi = yetiskin,
                        Tarih = DateTime.Now,
                        AppUserId = kullaniciid,
                        OdenenTutar = model.OdenenTutar,
                        Baslangic = baslangic,
                        Bitis = bitis,
                        PaymentId = payment.PaymentId,
                        ConversationId = payment.ConversationId
                    });
                    return View("Success");
                }
            }

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == id).ToList();
            List<OtelViewModel> ModelOtel = new List<OtelViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelViewModel Otelmodel = new OtelViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                Otelmodel.Picture = item.TurBilgileris.Picture;
                Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
                Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = yetiskin * item.CiftKisilikOda + cocuk * item.Cocuk_3_6_Yas;
            }
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Yetiskin = yetiskin;
            ViewBag.Cocuk = cocuk;
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.otelid = id;
            ViewBag.TurId = TurId;
            ViewBag.KullanıId = appUser.Id;
            return View(model);
        }

        private Payment PaymentProcess(RezervasyonOdemeViewModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-0HnLVSknglMMiDt5V5xakGLolWmMxLG1";
            options.SecretKey = "sandbox-WmhRke2t0wmu1xocGQd3DJLml0r996yS";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";


            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = Guid.NewGuid().ToString();
            request.Price = model.OdenenTutar.ToString().Split(",")[0];
            request.PaidPrice = model.OdenenTutar.ToString().Split(",")[0];
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = model.TurId.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CartName;
            paymentCard.CardNumber = model.CartNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.CVV;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //paymentCard.CardHolderName = "John Doe";
            //paymentCard.CardNumber = "5528790000000008";
            //paymentCard.ExpireMonth = "12";
            //paymentCard.ExpireYear = "2030";
            //paymentCard.Cvc = "123";



            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = model.TurId.ToString();
            firstBasketItem.Name = model.TurId.ToString();
            firstBasketItem.Category1 = model.TurId.ToString();
            firstBasketItem.Category2 = model.TurId.ToString();
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = model.OdenenTutar.ToString().Split(",")[0];
            basketItems.Add(firstBasketItem);
        
            request.BasketItems = basketItems;

            return Payment.Create(request, options);

        }

        public async Task<IActionResult> Rezervasyonlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<Rezervasyon> rezervasyon = _rezervasyonService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).Where(x => x.Durum == true).Where(x => x.Baslangic >= DateTime.Now).ToList();
            
            ViewBag.Rezervasyon = rezervasyon;
            ViewBag.Sayim = rezervasyon.Count;
            return View();
        }

        public async Task<IActionResult> IptalRezervasyonlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<Rezervasyon> rezervasyoniptal = _rezervasyonService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).Where(x => x.Durum == false).ToList();
            ViewBag.Rezervasyoniptal = rezervasyoniptal;
            ViewBag.SayimIptal = rezervasyoniptal.Count;

            return View();
        }

        public async Task<IActionResult> GecmisRezervasyonlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<Rezervasyon> rezervasyon = _rezervasyonService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).Where(x => x.Durum == true).Where(x => x.Baslangic < DateTime.Now).ToList();
            ViewBag.Rezervasyon = rezervasyon;
            ViewBag.Sayim = rezervasyon.Count;
            return View();
        }


        public IActionResult RezervasyonİptalKaldir(int id)
        {
            var tur = _rezervasyonService.GetirIdile(id);
            RezervasyonViewModel model = new RezervasyonViewModel
            {
                TurId = tur.TurId,
                AppUserId = tur.AppUserId,
                OtelId = tur.OtelId,
                RezervasyonId = tur.Id,
                Yad = tur.Yad,
                Ycinsiyet = tur.Ycinsiyet,
                Ysoyad = tur.Ysoyad,
                Tarih = tur.Tarih,
                Telefon = tur.Email,
                Email = tur.Email,
                CocukSayisi = tur.CocukSayisi,
                YetiskinSayisi = tur.YetiskinSayisi,
                OdenenTutar = tur.OdenenTutar,
                Ytc = tur.Ytc,

            };

            List<OtelBilgileri> OtelBilgileri = _otelBilgileriService.GetirTumTablolarlaOtel().Where(x => x.OtelBilgiId == tur.OtelId).ToList();
            List<OtelViewModel> ModelOtel = new List<OtelViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelViewModel Otelmodel = new OtelViewModel();
                Otelmodel.OtelBilgiId = item.OtelBilgiId;
                Otelmodel.TurId = item.TurId;
                Otelmodel.CiftKisilikOda = item.CiftKisilikOda;
                Otelmodel.IlaveYatak = item.IlaveYatak;
                Otelmodel.TekKisilikOda = item.TekKisilikOda;
                Otelmodel.Cocuk_3_6_Yas = item.Cocuk_3_6_Yas;
                Otelmodel.Cocuk_7_12_Yas = item.Cocuk_7_12_Yas;
                Otelmodel.Aciklama = item.Aciklama;
                Otelmodel.FiyatTanimi = item.FiyatTanimi;
                Otelmodel.TurAltKategori = item.TurBilgileris.TurAltKategori;
                Otelmodel.BitisTarihi = item.TurBilgileris.BitisTarihi;
                Otelmodel.BaslangicTarihi = item.TurBilgileris.BaslangicTarihi;
                Otelmodel.Picture = item.TurBilgileris.Picture;
                Otelmodel.TurBasligi = item.TurBilgileris.TurBasligi;
                Otelmodel.ParaBirimi = item.TurBilgileris.ParaBirimi;
                ModelOtel.Add(Otelmodel);
            }
            ViewBag.Yetiskin = tur.YetiskinSayisi;
            ViewBag.Cocuk = tur.CocukSayisi;
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.otelid = tur.OtelId;
            ViewBag.TurId = tur.TurId;
            return View(model);
        }

        public IActionResult Kaldir(int id)
        {
            var getir = _rezervasyonService.GetirIdile(id);
            getir.Durum = false;
            _rezervasyonService.Guncelle(getir);
            return RedirectToAction("Rezervasyonlarim");
        }

        public IActionResult Degerlendir(int TurId)
        {
            List<Rezervasyon> turs = _rezervasyonService.GetirTumTablolarla().Where(x => x.TurBilgileris.TurId == TurId).ToList();
            ViewBag.Rezervasyon = turs;
            return View();
        }
        [HttpPost]
        public IActionResult Degerlendir(int fiyatdeger, int hizmetdeger, int temizdeger, int perdeger, int oteldeger)
        {
            return View();
        }

    }
}
