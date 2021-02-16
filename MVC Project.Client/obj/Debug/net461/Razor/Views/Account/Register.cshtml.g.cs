#pragma checksum "C:\Users\aleksejs.zubovs\source\repos\MVC Project (online shop)\MVC Project.Client\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4021c2bbb8aa96f17a7856c598ca12cece98c808"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Register.cshtml", typeof(AspNetCore.Views_Account_Register))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4021c2bbb8aa96f17a7856c598ca12cece98c808", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"141199fa1a33e8dbc104f75dff8277161c4f044c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVC_Project.Client.Models.UserRegisterModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 1016, true);
            WriteLiteral(@"
<h2>Registration</h2>

<form asp-action=""Register"" asp-controller=""Account"">
    <div class=""validation"" asp-validation-summary=""All""></div>

    <div class=""form-group"">
        <label asp-for=""Username"">Username</label>
        <input type=""text"" asp-for=""Username"" />
        <span asp-validation-for=""Username"" />
    </div>

    <div class=""form-group"">
        <label asp-for=""Email"">Email</label>
        <input type=""text"" asp-for=""Email"" />
        <span asp-validation-for=""Email"" />
    </div>

    <div class=""form-group"">
        <label asp-for=""Password"">Password</label>
        <input asp-for=""Password"" />
        <span asp-validation-for=""Password"" />
    </div>

    <div class=""form-group"">
        <label asp-for=""ConfirmPassword"">ConfirmPassword</label>
        <input asp-for=""ConfirmPassword"" />
        <span asp-validation-for=""ConfirmPassword"" />
    </div>

    <div class=""form-group"">
        <input type=""submit"" value=""Register"" />
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC_Project.Client.Models.UserRegisterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591