#pragma checksum "C:\Users\aleksejs.zubovs\source\repos\MVC Project (online shop)\MVC Project.Client\Views\Account\SignIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aad1a27e75ea03e77b59bb1a0abb5090f45d1507"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_SignIn), @"mvc.1.0.view", @"/Views/Account/SignIn.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/SignIn.cshtml", typeof(AspNetCore.Views_Account_SignIn))]
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
#line 1 "C:\Users\aleksejs.zubovs\source\repos\MVC Project (online shop)\MVC Project.Client\Views\_ViewImports.cshtml"
using MVC_Project.Client;

#line default
#line hidden
#line 2 "C:\Users\aleksejs.zubovs\source\repos\MVC Project (online shop)\MVC Project.Client\Views\_ViewImports.cshtml"
using MVC_Project.Client.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aad1a27e75ea03e77b59bb1a0abb5090f45d1507", @"/Views/Account/SignIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"141199fa1a33e8dbc104f75dff8277161c4f044c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_SignIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVC_Project.Client.Models.UserLoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 631, true);
            WriteLiteral(@"
<h2>Sign in</h2>

<form asp-action=""SignIn"" asp-controller=""Account"">
    <div class=""validation"" asp-validation-summary=""All""></div>

    <div class=""form-group"">
        <label asp-for=""Username"">Username</label>
        <input type=""text"" asp-for=""Username"" />
        <span asp-validation-for=""Username"" />
    </div>

    <div class=""form-group"">
        <label asp-for=""Password"">Password</label>
        <input type=""password"" asp-for=""Password"" />
        <span asp-validation-for=""Password"" />
    </div>

    <div class=""form-group"">
        <input type=""submit"" value=""Sign in""/>
    </div>
</form>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC_Project.Client.Models.UserLoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
