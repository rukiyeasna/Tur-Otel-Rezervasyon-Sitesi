#pragma checksum "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3e82b6068e7adb0b41ccb18b4f78dfab533100d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dokumantasyon_OtelRezervasyonListe), @"mvc.1.0.view", @"/Areas/Admin/Views/Dokumantasyon/OtelRezervasyonListe.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3e82b6068e7adb0b41ccb18b4f78dfab533100d", @"/Areas/Admin/Views/Dokumantasyon/OtelRezervasyonListe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f90abaa1aa2c36f3471b4fdda1bd7af29dca26b0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dokumantasyon_OtelRezervasyonListe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OtelRezervasyonViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OtelRezervasyonIptal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Rezervasyon", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-rounded btn-fw"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
  
    ViewData["Title"] = "OtelRezervasyonListe";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">AKT??F OTEL REZERVASYONLARI</h4>
                <p class=""card-description"">
                </p>
                <div class=""table-responsive"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>G??rsel</th>
                                <th>Ad-Soyad</th>
                                <th>Telefon</th>
                                <th>Ba??lang???? Tarihi</th>
                                <th>Biti?? Tarihi</th>
                                <th>??denen Tutar</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 27 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td ");
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e3e82b6068e7adb0b41ccb18b4f78dfab533100d6021", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1238, "~/img/", 1238, 6, true);
#nullable restore
#line 30 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
AddHtmlAttributeValue("", 1244, item.Picture, 1244, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 30 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
AddHtmlAttributeValue("", 1264, item.Picture, 1264, 13, false);

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
#line 31 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                   Write(item.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 31 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                            Write(item.Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                   Write(item.Telefon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                   Write(item.BaslangicTarih.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                   Write(item.BitisTarih.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                   Write(item.OdenenTutar);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                                </tr>\r\n");
#nullable restore
#line 37 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">AKT??F OTEL REZERVASYONLARI(??creti ??denmemi??)</h4>
                <p class=""card-description"">
                </p>
                <div class=""table-responsive"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>G??rsel</th>
                                <th>Ad-Soyad</th>
                                <th>Telefon</th>
                                <th>Ba??lang???? Tarihi</th>
                                <th>Biti?? Tarihi</th>
                                <th>??denecek Tutar</th>
                                <th></th>
                            </tr>
             ");
            WriteLiteral("           </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 67 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                             foreach (var item in ViewBag.rezervasyon)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td ");
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e3e82b6068e7adb0b41ccb18b4f78dfab533100d11752", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3020, "~/img/", 3020, 6, true);
#nullable restore
#line 70 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
AddHtmlAttributeValue("", 3026, item.Picture, 3026, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 70 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
AddHtmlAttributeValue("", 3046, item.Picture, 3046, 13, false);

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
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 71 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                               Write(item.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 71 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                        Write(item.Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 72 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                               Write(item.Telefon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 73 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                               Write(item.BaslangicTarih.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 74 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                               Write(item.BitisTarih.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 75 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                               Write(item.OdenecekTutar);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3e82b6068e7adb0b41ccb18b4f78dfab533100d15647", async() => {
                WriteLiteral("??ptal Et");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"
                                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 78 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\Dokumantasyon\OtelRezervasyonListe.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OtelRezervasyonViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
