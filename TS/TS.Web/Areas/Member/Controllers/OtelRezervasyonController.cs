using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IyzipayCore;
using IyzipayCore.Model;
using IyzipayCore.Request;
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
    public class OtelRezervasyonController : Controller
    {
        private readonly IOtelRezervasyonService _otelRezervasyonService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOtelOdaService _otelOdaService;
        private readonly IOtelPuanService _otelPuanService;
        public OtelRezervasyonController(IOtelRezervasyonService otelRezervasyonService, UserManager<AppUser> userManager, IOtelOdaService otelOdaService, IOtelPuanService otelPuanService)
        {
            _otelRezervasyonService = otelRezervasyonService;
            _userManager = userManager;
            _otelOdaService = otelOdaService;
            _otelPuanService = otelPuanService;
        }
        public async Task<IActionResult> Index(int otelid, int otelodaid)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;

            List<OtelOda> OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == otelodaid).ToList();
            List<OtelOdaViewModel> ModelOtel = new List<OtelOdaViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelOdaViewModel Otelmodel = new OtelOdaViewModel();
                Otelmodel.Id = item.Id;
                Otelmodel.OtelId = item.OtelId;
                Otelmodel.OtelAd = item.Otels.OtelAd;
                Otelmodel.GirisTarihi = item.GirisTarihi;
                Otelmodel.CikisTarihi = item.CikisTarihi;
                Otelmodel.Sehir = item.Otels.Sehir;
                Otelmodel.Picture = item.Otels.Picture;
                Otelmodel.OdaTipi = item.OdaTipi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = item.Fiyat;
                ViewBag.ParaBirimi = item.ParaBirimi;
                ViewBag.Giris = item.GirisTarihi;
                ViewBag.Cikis = item.CikisTarihi;
            }
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.OtelId = otelid;
            ViewBag.OtelOdaId = otelodaid;
            return View(new OtelOdemeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(OtelOdemeViewModel model, int kullaniciid, int otelid, int otelodaid, int odenen, DateTime giris, DateTime cikis)
        {
            if (ModelState.IsValid)
            {
                var payment = PaymentProcess(model);
                if (payment.Status == "success")
                {
                    _otelRezervasyonService.Kaydet(new OtelRezervasyon
                    {
                        Id = model.Id,
                        OtelId = otelid,
                        OtelOdaId = otelodaid,
                        OdenenTutar = odenen,
                        BaslangicTarih = giris,
                        BitisTarih = cikis,
                        Ad = model.Ad,
                        Soyad = model.Soyad,
                        Tarih = DateTime.Now,
                        Tc = model.Tc,
                        Cinsiyet = model.Cinsiyet,
                        AppUserId = kullaniciid,
                        Email = model.Email,
                        Telefon = model.Telefon,
                        Durum = true,
                        PaymentId = payment.PaymentId,
                        ConversationId = payment.ConversationId
                    });

                    return RedirectToAction("OtelRezervasyonlarim");
                }
            }

            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.KullanıId = appUser.Id;

            List<OtelOda> OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == otelodaid).ToList();
            List<OtelOdaViewModel> ModelOtel = new List<OtelOdaViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelOdaViewModel Otelmodel = new OtelOdaViewModel();
                Otelmodel.Id = item.Id;
                Otelmodel.OtelId = item.OtelId;
                Otelmodel.OtelAd = item.Otels.OtelAd;
                Otelmodel.GirisTarihi = item.GirisTarihi;
                Otelmodel.CikisTarihi = item.CikisTarihi;
                Otelmodel.Sehir = item.Otels.Sehir;
                Otelmodel.Picture = item.Otels.Picture;
                Otelmodel.OdaTipi = item.OdaTipi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = item.Fiyat;
                ViewBag.ParaBirimi = item.ParaBirimi;
                ViewBag.Giris = item.GirisTarihi;
                ViewBag.Cikis = item.CikisTarihi;
            }
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.OtelId = otelid;
            ViewBag.OtelOdaId = otelodaid;

            return View(model);
        }



        private Payment PaymentProcess(OtelOdemeViewModel model)
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
            request.BasketId = model.OtelId.ToString();
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
            firstBasketItem.Id = model.OtelId.ToString();
            firstBasketItem.Name = model.OtelId.ToString();
            firstBasketItem.Category1 = model.OtelId.ToString();
            firstBasketItem.Category2 = model.OtelId.ToString();
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = model.OdenenTutar.ToString().Split(",")[0];
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;

            return Payment.Create(request, options);

        }

        public async Task<IActionResult> OtelRezervasyonlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<OtelRezervasyon> rezervasyon = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).Where(x => x.Durum == true).Where(x => x.BaslangicTarih >= DateTime.Now).ToList();
            ViewBag.Rezervasyon = rezervasyon;
            ViewBag.Sayim = rezervasyon.Count;
            return View();
        }
        public async Task<IActionResult> IptalOtelRezervasyonlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<OtelRezervasyon> rezervasyon = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).Where(x => x.Durum == false).ToList();
            ViewBag.Rezervasyon = rezervasyon;
            ViewBag.Sayim = rezervasyon.Count;
            return View();
        }

        public async Task<IActionResult> GecmisOtelRezervasyonlarim()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            List<OtelRezervasyon> rezervasyon = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.AppUserId == kullaniciId).Where(x => x.Durum == true).Where(x => x.BaslangicTarih < DateTime.Now).ToList();
            ViewBag.Rezervasyon = rezervasyon;
            ViewBag.Sayim = rezervasyon.Count;
            ViewBag.kullaniciId = kullaniciId;
            return View();
        }

        public IActionResult RezervasyonİptalKaldir(int id)
        {
            var tur = _otelRezervasyonService.GetirIdile(id);
            OtelRezervasyonListViewModel model = new OtelRezervasyonListViewModel
            {
                Id = tur.Id,
                OtelId = tur.OtelId,
                OtelOdaId = tur.OtelOdaId,
                OdenenTutar = tur.OdenenTutar,
                BaslangicTarih = tur.BaslangicTarih,
                BitisTarih = tur.BitisTarih,
                Ad = tur.Ad,
                Soyad = tur.Soyad,
                Tarih = DateTime.Now,
                Tc = tur.Tc,
                Cinsiyet = tur.Cinsiyet,
                AppUserId = tur.AppUserId,
                Email = tur.Email,
                Telefon = tur.Telefon,
                //Durum = true
            };
            //var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.KullanıId = appUser.Id;

            List<OtelOda> OtelBilgileri = _otelOdaService.GetirOtelBilgileri().Where(x => x.Id == tur.OtelOdaId).ToList();
            List<OtelOdaViewModel> ModelOtel = new List<OtelOdaViewModel>();
            foreach (var item in OtelBilgileri)
            {
                OtelOdaViewModel Otelmodel = new OtelOdaViewModel();
                Otelmodel.Id = item.Id;
                Otelmodel.OtelId = item.OtelId;
                Otelmodel.OtelAd = item.Otels.OtelAd;
                Otelmodel.GirisTarihi = item.GirisTarihi;
                Otelmodel.CikisTarihi = item.CikisTarihi;
                Otelmodel.Sehir = item.Otels.Sehir;
                Otelmodel.Picture = item.Otels.Picture;
                Otelmodel.OdaTipi = item.OdaTipi;
                ModelOtel.Add(Otelmodel);
                ViewBag.Odenecektutar = item.Fiyat;
                ViewBag.ParaBirimi = item.ParaBirimi;
                ViewBag.Giris = item.GirisTarihi;
                ViewBag.Cikis = item.CikisTarihi;
            }
            ViewBag.OtelBilgi = ModelOtel;
            ViewBag.OtelId = tur.OtelId;
            ViewBag.OtelOdaId = tur.OtelOdaId;
            return View(model);
        }

        public IActionResult Kaldir(int id)
        {
            var getir = _otelRezervasyonService.GetirIdile(id);
            getir.Durum = false;
            _otelRezervasyonService.Guncelle(getir);
            return RedirectToAction("IptalOtelRezervasyonlarim");
        }

        public async Task<IActionResult> Degerlendir(int OtelId, int id, int AppUserId)
        {
            List<OtelRezervasyon> turs = _otelRezervasyonService.GetirTumTablolarla().Where(x => x.Otels.OtelId == OtelId).Where(x => x.Id == id).ToList();
            List<OtelPuan> degerl = _otelPuanService.GetirHepsi().Where(x => x.OtelId == OtelId)
             .Where(x => x.AppUserId == AppUserId).ToList();
            ViewBag.Rezervasyon = turs;
            ViewBag.OtelId = OtelId;
            ViewBag.App = AppUserId;
            foreach (var item in degerl)
            {
                if (item.AppUserId == AppUserId && item.OtelId == OtelId)
                {
                    return RedirectToAction("Yorumlarim", "Iletisim");
                }
            }
            return View(new OtelPuanViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Degerlendir(OtelPuanViewModel model, int fiyatdeger, int hizmetdeger, int temizdeger, int perdeger, int odadeger, int yiyecekdeger, int OtelId)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var kullaniciId = appUser.Id;
            var username = appUser.UserName;

            if (ModelState.IsValid)
            {
                _otelPuanService.Kaydet(new OtelPuan
                {
                    Id = model.OtelPuanId,
                    FiyatDeger = fiyatdeger,
                    HizmetDeger = hizmetdeger,
                    TemizDeger = temizdeger,
                    PersonelDeger = perdeger,
                    OdaDeger = odadeger,
                    YiyecekDeger = yiyecekdeger,
                    OtelId = OtelId,
                    AppUserId = kullaniciId,
                    Yorum = model.Yorum,
                    Username = username
                });

                return RedirectToAction("GecmisOtelRezervasyonlarim");
            }
            return View();
        }

    }
}
