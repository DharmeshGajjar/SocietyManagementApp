#pragma checksum "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "277c6dbfb8876b7e78347a7a03711e14db6d98e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Company), @"mvc.1.0.view", @"/Views/Login/Company.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"277c6dbfb8876b7e78347a7a03711e14db6d98e7", @"/Views/Login/Company.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e34048236c8e2e013947ad8567f788dc9dee931", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Company : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SocietyManagementWeb.Models.CompanyLIstModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Template/plugins/select2/js/select2.full.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
  
    string messageType = string.Empty;
    string message = string.Empty;
    if (TempData != null && TempData.Count > 0 && TempData["TempMessage"] != null && TempData["TempMessageType"] != null)
    {
        messageType = TempData["TempMessageType"].ToString();
        message = TempData["TempMessage"].ToString();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277c6dbfb8876b7e78347a7a03711e14db6d98e74601", async() => {
                WriteLiteral(@"

    <meta name=""viewport"" content=""width=device-width"" />
    <title>Account</title>
    <!-- Latest compiled and minified CSS -->
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"" integrity=""sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"" crossorigin=""anonymous"">
    <script src=""https://code.jquery.com/jquery-3.3.1.slim.min.js"" integrity=""sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"" crossorigin=""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"" integrity=""sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"" crossorigin=""anonymous""></script>
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"" integrity=""sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"" crossorigin=""anonymous""></script>

    <script src=""/Template/plugins/jquery/jquery.min.js""></scr");
                WriteLiteral("ipt>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277c6dbfb8876b7e78347a7a03711e14db6d98e75959", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""//cdn.jsdelivr.net/npm/sweetalert2@11""></script>
    <style>
        .bg-image-vertical {
            position: relative;
            overflow: hidden;
            background-repeat: no-repeat;
            background-position: right center;
            background-size: auto 100%;
            background-color: #1b1e24;
        }

        tr td,
        tr th {
            padding: .20rem !important
        }

        tr td {
            color: blue;
            cursor: pointer
        }
    </style>
    <script>
         var message = '");
#nullable restore
#line 52 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                   Write(message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        var messageType = \'");
#nullable restore
#line 53 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                      Write(messageType);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })

        $(document).ready(function () {
            if (message != '' && messageType != '') {
                Toast.fire({
                    icon: messageType,
                    title: message
                })
            }

        })
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277c6dbfb8876b7e78347a7a03711e14db6d98e79552", async() => {
                WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""card mt-3"">
            <div class=""card-header p-0 pt-1 text-center"">
                <div class=""col-md-12 text-center"">
                    <div class=""row"">
                        <div class=""col-md-11"" style=""font-family:Verdana;font-size:large;color:blue"">
                            <h4>Company List</h4>
                        </div>
                        <div class=""col-md-1"">
                            <a href=""#"" onclick=""onLogOut()"" class=""nav-link"" style=""font-family:Verdana;font-size:large;color:blue"">
                                <i class=""far fa-circle nav-icon""></i>
                                <img src=""/Template/dist/img/Logout.png"" alt=""Logout"" class=""brand-image img-circle elevation-3"" style=""opacity: .8;height: 35px;"">
                            </a>
                        </div>
                    </div>                 
                </div>
            </div>
            <div class=""card-body"">
   ");
                WriteLiteral(@"             <div class=""col-md-12"">
                    <table class=""table  table-bordered"">
                        <thead>
                            <tr>
                                <th>
                                    Client
                                </th>
                                <th>
                                    Code
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Start-End Date
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 117 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                             if (Model != null && Model.Count > 0)
                            {
                                foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr");
                BeginWriteAttribute("onclick", " onclick=\"", 4904, "\"", 4983, 5);
                WriteAttributeValue("", 4914, "location.href=\'/login/company?companyId=", 4914, 40, true);
#nullable restore
#line 121 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
WriteAttributeValue("", 4954, item.Id, 4954, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4962, "&yearId=", 4962, 8, true);
#nullable restore
#line 121 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
WriteAttributeValue("", 4970, item.YearId, 4970, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4982, "\'", 4982, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 123 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                       Write(item.ClientNm);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 126 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                       Write(item.COde);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 129 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 132 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                       Write(item.StartDate);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 132 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                                         Write(item.EndDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 135 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
            WriteLiteral(@"
</html>

<script type=""text/javascript"">
        function onLogOut() {
        Swal.fire({
            title: 'Alert?',
            text: ""Are you sure want to logout ?"",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = '");
#nullable restore
#line 158 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\Login\Company.cshtml"
                                   Write(Url.Action("LogOut","Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            }\r\n        });\r\n    }\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SocietyManagementWeb.Models.CompanyLIstModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
