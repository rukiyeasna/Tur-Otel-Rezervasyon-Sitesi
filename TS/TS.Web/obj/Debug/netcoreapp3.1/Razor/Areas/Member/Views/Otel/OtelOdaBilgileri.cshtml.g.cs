#pragma checksum "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59e313216f1f63172147c799bf3b4cbc816f6d1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Otel_OtelOdaBilgileri), @"mvc.1.0.view", @"/Areas/Member/Views/Otel/OtelOdaBilgileri.cshtml")]
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
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\_ViewImports.cshtml"
using TS.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\_ViewImports.cshtml"
using TS.Web.Areas.Member.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\_ViewImports.cshtml"
using TS.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59e313216f1f63172147c799bf3b4cbc816f6d1f", @"/Areas/Member/Views/Otel/OtelOdaBilgileri.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00a9bae36bedd6bd7088cd4ef17d8a1fe97d233d", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Otel_OtelOdaBilgileri : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OtelOdaViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:1250px; height:500px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OtelRezervasyon", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
  
    ViewData["Title"] = "OtelOdaBilgileri";
    Layout = "~/Areas/Member/Views/Shared/_MemberLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-2"" style=""margin-top:30px; margin-left:20px;"">
        <div class=""card"">
            <h5 class=""card-header"" style=""font-size:medium;"">Oda Özellikleri</h5>
            <div class=""card-body"">
                <h5 class=""card-title""></h5>
                <p class=""card-text"">
");
#nullable restore
#line 13 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                     foreach (var item in ViewBag.Gorsel)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <ul>\r\n                            <li>\r\n                                ");
#nullable restore
#line 17 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                           Write(item.Ozellik);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n                        </ul>\r\n");
#nullable restore
#line 20 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-9\" style=\"margin-top:30px;\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-8\">\r\n                <h3 style=\"color:black;\">");
#nullable restore
#line 27 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                                    Write(ViewBag.Otelad.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 27 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                                                                Write(ViewBag.OdaTipi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n            </div>\r\n        </div>\r\n\r\n");
            WriteLiteral("        <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n            <ol class=\"carousel-indicators\">\r\n");
#nullable restore
#line 34 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                 for (int j = 0; j < ViewBag.sayi; j++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li data-target=\"#myCarousel\" data-slide-to=\"");
#nullable restore
#line 36 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                                                            Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></li>\r\n");
#nullable restore
#line 37 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ol>\r\n            <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 40 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                  int i = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                 foreach (var item in ViewBag.Image)
                {
                    i++;
                    var active = i == 1 ? "active" : "";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("class", " class=\"", 1649, "\"", 1669, 2);
            WriteAttributeValue("", 1657, "item", 1657, 4, true);
#nullable restore
#line 45 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
WriteAttributeValue(" ", 1661, active, 1662, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "59e313216f1f63172147c799bf3b4cbc816f6d1f9738", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1707, "~/img/", 1707, 6, true);
#nullable restore
#line 46 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
AddHtmlAttributeValue("", 1713, item.Picture, 1713, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 46 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
AddHtmlAttributeValue("", 1733, item.Picture, 1733, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 48 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
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
            WriteLiteral(@"        <div class=""table-responsive-xl"">
            <table class=""table"" style=""margin-top:30px;"">
                <thead class=""table-dark"" style=""font-size:medium;"">
                    <tr>
                        <th>Otel Adı</th>
                        <th>Oda Tipi</th>
                        <th>İçerik Bilgisi</th>
                        <th>Fiyat</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 73 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr style=\"font-size:small;\">\r\n                            <td>");
#nullable restore
#line 76 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                           Write(item.OtelAd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 77 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                           Write(item.OdaTipi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 78 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                           Write(item.IcerikBilgisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 79 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                           Write(item.Fiyat);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                        </tr>\r\n");
#nullable restore
#line 81 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr style=\"text-align:right;\">\r\n                        <td></td>\r\n                        <td></td>\r\n                        <td></td>\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59e313216f1f63172147c799bf3b4cbc816f6d1f15092", async() => {
                WriteLiteral("Rezervasyon Yap");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-otelid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                                                             WriteLiteral(ViewBag.OtelId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["otelid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-otelid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["otelid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Member\Views\Otel\OtelOdaBilgileri.cshtml"
                                                                                                   WriteLiteral(ViewBag.OtelOdaId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["otelodaid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-otelodaid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["otelodaid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    </tr>\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OtelOdaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591