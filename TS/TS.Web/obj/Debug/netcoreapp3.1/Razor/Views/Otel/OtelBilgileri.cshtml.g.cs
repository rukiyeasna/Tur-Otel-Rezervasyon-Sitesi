#pragma checksum "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9ad4e2f8d8cc861eb3f04b45538a5d6e737e6b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Otel_OtelBilgileri), @"mvc.1.0.view", @"/Views/Otel/OtelBilgileri.cshtml")]
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
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\_ViewImports.cshtml"
using TS.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9ad4e2f8d8cc861eb3f04b45538a5d6e737e6b9", @"/Views/Otel/OtelBilgileri.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90d0305082a103921175bc0fa4c60b7ab63586aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Otel_OtelBilgileri : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OtelOdaListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SignIn", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-bs-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-bs-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Favorilerime Ekle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:1050px; height:500px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:360px; height:320px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OtelOdaBilgileri", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Otel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
  
    ViewData["Title"] = "OtelBilgileri";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-2"" style=""margin-top:30px; margin-left:20px;"">
        <div class=""card"">
            <h5 class=""card-header"" style=""font-size:medium;"">Otel Özellikleri</h5>
            <div class=""card-body"">
                <h5 class=""card-title""></h5>
                <p class=""card-text"">
                    ");
#nullable restore
#line 14 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
               Write(Html.Raw(@ViewBag.Ozellik));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-9\" style=\"margin-top:30px;\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-9\">\r\n                <h3 style=\"color:black;\">");
#nullable restore
#line 21 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                    Write(ViewBag.Otelad.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9ad4e2f8d8cc861eb3f04b45538a5d6e737e6b98459", async() => {
                WriteLiteral("<i class=\"icon-heart\" style=\"text-decoration:none; color:black;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" </h3>\r\n");
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n");
            WriteLiteral("        <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n            <ol class=\"carousel-indicators\">\r\n");
#nullable restore
#line 29 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                 for (int j = 0; j < ViewBag.sayi; j++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li data-target=\"#myCarousel\" data-slide-to=\"");
#nullable restore
#line 31 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                            Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></li>\r\n");
#nullable restore
#line 32 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ol>\r\n            <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 35 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                  int i = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                 foreach (var item in ViewBag.Image)
                {
                    i++;
                    var active = i == 1 ? "active" : "";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("class", " class=\"", 1703, "\"", 1723, 2);
            WriteAttributeValue("", 1711, "item", 1711, 4, true);
#nullable restore
#line 40 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
WriteAttributeValue(" ", 1715, active, 1716, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b9ad4e2f8d8cc861eb3f04b45538a5d6e737e6b912236", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1761, "~/img/", 1761, 6, true);
#nullable restore
#line 41 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
AddHtmlAttributeValue("", 1767, item.Picture, 1767, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 41 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
AddHtmlAttributeValue("", 1787, item.Picture, 1787, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 43 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
            <a class=""left carousel-control"" href=""#myCarousel"" data-slide=""prev"">
                <span class=""glyphicon glyphicon-chevron-left""></span>
                <span class=""sr-only"">Previous</span>
            </a>
            <a class=""right carousel-control"" href=""#myCarousel"" data-slide=""next"">
                <span class=""glyphicon glyphicon-chevron-right""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>

");
            WriteLiteral(@"
    </div>
    <div id=""fh5co-blog-section"" class=""fh5co-section-gray"">
        <div class=""container"">
            <div class=""row"" style=""margin-top:30px;"">
                <div style=""margin-top:30px;"" class=""col-md-8 col-md-offset-2 text-center heading-section animate-box"">
                    <h3> ");
#nullable restore
#line 62 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                    Write(ViewBag.Otelad);

#line default
#line hidden
#nullable disable
            WriteLiteral("  Odaları</h3>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"container\">\r\n            <div class=\"row row-bottom-padded-md\">\r\n");
#nullable restore
#line 68 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4 col-md-4 col-sm-6\">\r\n                        <div class=\"fh5co-blog animate-box\">\r\n                            <a ");
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b9ad4e2f8d8cc861eb3f04b45538a5d6e737e6b916275", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3254, "~/img/", 3254, 6, true);
#nullable restore
#line 72 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
AddHtmlAttributeValue("", 3260, item.Picture, 3260, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n                            <div class=\"blog-text\">\r\n                                <div class=\"prod-title\">\r\n                                    <h3><a ");
            WriteLiteral(">");
#nullable restore
#line 75 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                                                                                      Write(item.OdaTipi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                                    <span style=\"color: rgba(0, 0, 0, 0.6);\" class=\"posted_by\">");
#nullable restore
#line 76 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                                                          Write(item.IcerikBilgisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <span class=\"posted_by\">");
#nullable restore
#line 77 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                       Write(item.GirisTarihi.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 77 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                                                                Write(item.CikisTarihi.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <span class=\"comment\">");
#nullable restore
#line 78 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                     Write(item.Fiyat);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</span>\r\n                                    <p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9ad4e2f8d8cc861eb3f04b45538a5d6e737e6b919998", async() => {
                WriteLiteral("DETAYLAR...");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                                                                                                                            WriteLiteral(item.OtelAd);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["otelad"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-otelad", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["otelad"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 84 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Views\Otel\OtelBilgileri.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OtelOdaListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591