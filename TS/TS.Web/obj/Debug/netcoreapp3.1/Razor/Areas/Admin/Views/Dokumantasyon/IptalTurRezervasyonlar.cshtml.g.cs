#pragma checksum "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "951c19be7c3af33e9f96175f08d6448b238e07c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dokumantasyon_IptalTurRezervasyonlar), @"mvc.1.0.view", @"/Areas/Admin/Views/Dokumantasyon/IptalTurRezervasyonlar.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\_ViewImports.cshtml"
using TS.Web.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\_ViewImports.cshtml"
using TS.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"951c19be7c3af33e9f96175f08d6448b238e07c0", @"/Areas/Admin/Views/Dokumantasyon/IptalTurRezervasyonlar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f90abaa1aa2c36f3471b4fdda1bd7af29dca26b0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dokumantasyon_IptalTurRezervasyonlar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RezerViewModel>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
  
    ViewData["Title"] = "IptalTurRezervasyonlar";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">İPTAL TUR REZERVASYONLARI</h4>
                <p class=""card-description"">
                </p>
                <div class=""table-responsive"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>Görsel</th>
                                <th>Ad-Soyad</th>
                                <th>Telefon</th>
                                <th>Kişi Sayısı</th>
                                <th>Tur Alt Kategori</th>
                                <th>Tur Başlığı</th>
                                <th>Başlangıç Tarihi</th>
                                <th>Bitiş Tarihi</th>
                                <th>Ödenen Tutar</th>
                                <th>Geri Ödenen Tutar</th>
                            </t");
            WriteLiteral("r>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td ");
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "951c19be7c3af33e9f96175f08d6448b238e07c05158", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1454, "~/img/", 1454, 6, true);
#nullable restore
#line 33 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
AddHtmlAttributeValue("", 1460, item.Picture, 1460, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 33 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
AddHtmlAttributeValue("", 1480, item.Picture, 1480, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.Yad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                             Write(item.Ysoyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.Telefon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 36 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.YetiskinSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Yetişkin ");
#nullable restore
#line 36 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                                                 Write(item.CocukSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Çocuk</td>\r\n                                    <td>");
#nullable restore
#line 37 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.TurAltKategori);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 38 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.TurBasligi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 39 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.BaslangicTarihi.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 40 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.BitisTarihi.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 41 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.OdenenTutar);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                                    <td>");
#nullable restore
#line 42 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.OdenenTutar);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                                </tr>\r\n");
#nullable restore
#line 44 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            WriteLiteral(@"<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">İPTAL TUR REZERVASYONLARI(Ücreti Ödenmemiş)</h4>
                <p class=""card-description"">
                </p>
                <div class=""table-responsive"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>Görsel</th>
                                <th>Ad-Soyad</th>
                                <th>Telefon</th>
                                <th>Kişi Sayısı</th>
                                <th>Tur Alt Kategori</th>
                                <th>Tur Başlığı</th>
                                <th>Başlangıç Tarihi</th>
                                <th>Bitiş Tarihi</th>
                                <th>Ödenecek Tutar</th>
                            </tr>
                        </thead>
  ");
            WriteLiteral("                      <tbody>\r\n");
#nullable restore
#line 80 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                             foreach (var item in ViewBag.Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td ");
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "951c19be7c3af33e9f96175f08d6448b238e07c012706", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3785, "~/img/", 3785, 6, true);
#nullable restore
#line 83 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
AddHtmlAttributeValue("", 3791, item.Picture, 3791, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 83 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
AddHtmlAttributeValue("", 3811, item.Picture, 3811, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 84 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.Yad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 84 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                             Write(item.Ysoyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 85 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.Telefon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 86 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.YetiskinSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Yetişkin ");
#nullable restore
#line 86 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                                                 Write(item.CocukSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Çocuk</td>\r\n                                    <td>");
#nullable restore
#line 87 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.TurAltKategori);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 88 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.TurBasligi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 89 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.Baslangic.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 90 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.Bitis.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 91 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"
                                   Write(item.OdenecekTutar);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                                </tr>\r\n");
#nullable restore
#line 93 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\IptalTurRezervasyonlar.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RezerViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591