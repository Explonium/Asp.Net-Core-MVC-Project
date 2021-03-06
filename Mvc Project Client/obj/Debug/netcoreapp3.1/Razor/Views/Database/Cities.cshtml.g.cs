#pragma checksum "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5415e24c93dde27eb8ff41b3e1fdeac5e6da72d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Database_Cities), @"mvc.1.0.view", @"/Views/Database/Cities.cshtml")]
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
#line 1 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\_ViewImports.cshtml"
using Mvc_Project_Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\_ViewImports.cshtml"
using Mvc_Project_Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\_ViewImports.cshtml"
using Mvc_Project_Client.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5415e24c93dde27eb8ff41b3e1fdeac5e6da72d3", @"/Views/Database/Cities.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"835a1325a47e4e65124f03071909278e35dc91a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Database_Cities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mvc_Project_Client.ViewModels.CitiesDatabaseViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Database", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url", new global::Microsoft.AspNetCore.Html.HtmlString("Database/UpdateCity"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
Write(await Component.InvokeAsync("Datalist", new { id = "Countries" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5415e24c93dde27eb8ff41b3e1fdeac5e6da72d34742", async() => {
                WriteLiteral(@"
    <div class=""form-row align-items-center"">
        <input name=""Id"" type=""hidden"" />
        <div class=""col-auto"">
            <input name=""Name"" class=""form-control"" placeholder=""Name"" type=""text"" />
        </div>

        <div class=""col-auto"">
            <input list=""Countries"" id=""country"" onchange=""updateDataList(this)"" class=""form-control"" placeholder=""Country"" />

            <input type=""hidden"" name=""CountryId"" id=""country-hidden"" />
        </div>
        <div class=""col-auto"">
            <input type=""submit"" class=""btn btn-primary"" formaction=""CreateCity"" value=""Create"" />
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 23 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
  
    foreach (var city in Model.Cities)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5415e24c93dde27eb8ff41b3e1fdeac5e6da72d37319", async() => {
                WriteLiteral("\r\n            <div class=\"form-row align-items-center\">\r\n                <input name=\"Id\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1092, "\"", 1108, 1);
#nullable restore
#line 28 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
WriteAttributeValue("", 1100, city.Id, 1100, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <div class=\"col-auto\">\r\n                    <input name=\"Name\" class=\"form-control\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 1225, "\"", 1243, 1);
#nullable restore
#line 30 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
WriteAttributeValue("", 1233, city.Name, 1233, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n\r\n                <div class=\"col-auto\">\r\n                    <input list=\"Countries\"");
                BeginWriteAttribute("id", " id=\"", 1358, "\"", 1379, 2);
#nullable restore
#line 34 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
WriteAttributeValue("", 1363, city.Id, 1363, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 1371, "country", 1372, 8, true);
                EndWriteAttribute();
                WriteLiteral(" onchange=\"updateDataList(this)\" class=\"form-control\" placeholder=\"Country\"");
                BeginWriteAttribute("value", " value=\"", 1455, "\"", 1541, 1);
#nullable restore
#line 34 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
WriteAttributeValue("", 1463, Model.Countries.FirstOrDefault(p => p.Key == city.CountryId.ToString()).Value, 1463, 78, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"CountryId\"");
                BeginWriteAttribute("id", " id=\"", 1604, "\"", 1632, 2);
#nullable restore
#line 35 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
WriteAttributeValue("", 1609, city.Id, 1609, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 1617, "country-hidden", 1618, 15, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1633, "\"", 1656, 1);
#nullable restore
#line 35 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
WriteAttributeValue("", 1641, city.CountryId, 1641, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n\r\n                <div class=\"col-auto\">\r\n                    <input type=\"submit\" class=\"btn btn-outline-danger\" formaction=\"DeleteCity\" value=\"Delete\" />\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 26 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
AddHtmlAttributeValue("", 901, city.Id, 901, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onchange", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 921, "AjaxFormSubmit(\'", 921, 16, true);
#nullable restore
#line 26 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
AddHtmlAttributeValue("", 937, city.Id, 937, 8, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 945, "\')", 945, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 43 "C:\Users\Алексей\Desktop\MVC Project\Mvc Project Client\Views\Database\Cities.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mvc_Project_Client.ViewModels.CitiesDatabaseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
