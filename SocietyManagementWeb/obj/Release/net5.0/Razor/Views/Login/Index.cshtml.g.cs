#pragma checksum "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e3e33b0048ce24b4cad9fdd86f345fa987b4716"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Index), @"mvc.1.0.view", @"/Views/Login/Index.cshtml")]
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
#line 1 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\_ViewImports.cshtml"
using SocietyManagementWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\_ViewImports.cshtml"
using SocietyManagementWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e3e33b0048ce24b4cad9fdd86f345fa987b4716", @"/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e34048236c8e2e013947ad8567f788dc9dee931", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e3e33b0048ce24b4cad9fdd86f345fa987b47164106", async() => {
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <title>Account</title>
    <!-- Latest compiled and minified CSS -->
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"" integrity=""sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"" crossorigin=""anonymous"">
    <script src=""https://code.jquery.com/jquery-3.3.1.slim.min.js"" integrity=""sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"" crossorigin=""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"" integrity=""sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"" crossorigin=""anonymous""></script>
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"" integrity=""sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"" crossorigin=""anonymous""></script>
    <style>
        .bg-image-vertical {
            position: r");
                WriteLiteral(@"elative;
            overflow: hidden;
            background-repeat: no-repeat;
            background-position: right center;
            background-size: auto 100%;
            background-color: #1b1e24;
        }
    </style>
    <script>
        $(document).ready(function () {
            var status = '");
#nullable restore
#line 29 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                     Write(Html.Raw(ViewBag.FocusType));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
            if (status != null && status != '') {
                if (status == ""1"") {
                    $(""#txtUsername"").focus();
                }
                if (status == ""2"") {
                    $(""#txtPassword"").focus();
                }
            }
            else {
                $(""#txtUsername"").focus();
            }
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e3e33b0048ce24b4cad9fdd86f345fa987b47167140", async() => {
                WriteLiteral(@"
    <section class=""vh-100 gradient-custom"" style=""background-color:#1b1e24"">
        <div class=""container py-5 h-100"" >
            <div class=""row d-flex justify-content-center align-items-center h-100"">
                <div class=""col-12 col-md-8 col-lg-6 col-xl-5"">
                    <div class=""card bg-dark text-white"" style=""border-radius: 1rem;"">
                        <div class=""card-body p-5 text-center"" style="" height: 400px;"">
                            <div class=""mb-md-5 mt-md-4 pb-5"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e3e33b0048ce24b4cad9fdd86f345fa987b47167965", async() => {
                    WriteLiteral("\r\n");
#nullable restore
#line 53 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                     if (ViewBag.Msg != null && ViewBag.Msg != "" && ViewBag.MsgType != null && ViewBag.MsgType != "")
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                         if (ViewBag.MsgType == "1")
                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                            <div class=\"alert alert-success\" role=\"alert\" style=\"font-size:medium;font-family:Nina\">\r\n                                                ");
#nullable restore
#line 58 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                           Write(ViewBag.Msg);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                            </div>\r\n");
#nullable restore
#line 60 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                            <div class=\"alert alert-danger\" role=\"alert\" style=\"font-size:medium;font-family:Nina\">\r\n                                                ");
#nullable restore
#line 64 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                           Write(ViewBag.Msg);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                            </div>\r\n");
#nullable restore
#line 66 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
                                         

                                    }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                <h2 class=\"fw-bold mb-2\" style=\"font-size:large\">Login to Account Panel</h2>\r\n                                    <br />\r\n\r\n                                    <div class=\"form-outline form-white mb-2\">\r\n");
                    WriteLiteral("                                        <input type=\"text\" id=\"txtUsername\" name=\"txtUsername\" class=\"form-control form-control-lg\" placeholder=\"Username\"\r\n                                               tabindex=\"1\"");
                    BeginWriteAttribute("value", " value=\"", 3947, "\"", 3972, 1);
#nullable restore
#line 75 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
WriteAttributeValue("", 3955, ViewBag.Username, 3955, 17, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                    </div>\r\n\r\n                                    <div class=\"form-outline form-white mb-4\">\r\n");
                    WriteLiteral("                                        <input type=\"password\"");
                    BeginWriteAttribute("value", " value=\"", 4254, "\"", 4279, 1);
#nullable restore
#line 80 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Index.cshtml"
WriteAttributeValue("", 4262, ViewBag.Password, 4262, 17, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" id=\"txtPassword\" name=\"txtPassword\" class=\"form-control form-control-lg\" placeholder=\"Password\" tabindex=\"2\" />\r\n                                    </div>\r\n\r\n");
                    WriteLiteral(@"                                    <button class=""btn btn-outline-light btn-lg px-5"" type=""submit""
                                            style=""background-color: #1caf9a; border-color: #1caf9a; width:100%"">
                                        Login
                                    </button>

                                    <div class=""col-md-12"" style=""margin-bottom:15px;display:block"">
                                        <a href=""/login/forgotpassword"" class=""btn btn-link btn-block"" style=""color: white"">Forgot your password?</a>
                                        &nbsp;
                                    </div>
                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591