#pragma checksum "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae19dad869a641199f5f3bb466bd9cfe2dcaa2ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_OtelSlider_OtelOdaListe), @"mvc.1.0.view", @"/Areas/Admin/Views/OtelSlider/OtelOdaListe.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae19dad869a641199f5f3bb466bd9cfe2dcaa2ee", @"/Areas/Admin/Views/OtelSlider/OtelOdaListe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f90abaa1aa2c36f3471b4fdda1bd7af29dca26b0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_OtelSlider_OtelOdaListe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OtelOdaViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; height:100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OtelOdaSliderEkleme", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OtelSlider", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
  
    ViewData["Title"] = "OtelOdaListe";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-bordered\">\r\n        <thead>\r\n");
            WriteLiteral("            <tr>\r\n                <th style=\"text-align:center;\">ODA G??RSEL</th>\r\n                <th>ID</th>\r\n                <th>OTEL AD</th>\r\n                <th>ODA T??P??</th>\r\n                <th>????ER??K B??LG??S??</th>\r\n");
            WriteLiteral("                <th>DAH??L B??LG??S??</th>\r\n                <th>F??YAT</th>\r\n                <th></th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 26 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td style=\"text-align:center;\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ae19dad869a641199f5f3bb466bd9cfe2dcaa2ee5857", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 941, "~/img/", 941, 6, true);
#nullable restore
#line 29 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
AddHtmlAttributeValue("", 947, item.Picture, 947, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
AddHtmlAttributeValue("", 967, item.Picture, 967, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                   Write(item.OtelAd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                   Write(item.OdaTipi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                   Write(item.IcerikBilgisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                    <td>");
#nullable restore
#line 36 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                   Write(item.Bilgi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                   Write(item.Fiyat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"text-align:center;\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae19dad869a641199f5f3bb466bd9cfe2dcaa2ee9645", async() => {
                WriteLiteral("Ekle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\casper\Desktop\ARSO\TS\TS.Web\Areas\Admin\Views\OtelSlider\OtelOdaListe.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n\r\n\r\n");
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
