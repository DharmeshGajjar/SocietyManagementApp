#pragma checksum "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afa103748116dc7afa988310ff527f7e5cdf53c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TrialBalance_Index), @"mvc.1.0.view", @"/Views/TrialBalance/Index.cshtml")]
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
#nullable restore
#line 2 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afa103748116dc7afa988310ff527f7e5cdf53c4", @"/Views/TrialBalance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e34048236c8e2e013947ad8567f788dc9dee931", @"/Views/_ViewImports.cshtml")]
    public class Views_TrialBalance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SocietyManagementWeb.Models.TrialBalanceModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int isAdministrator = HttpContextAccessor.HttpContext.Session.GetInt32("IsAdministrator").Value;
    List<SocietyManagementWeb.Models.TrialBalanceModel> trialbalList = ViewBag.trialbalList as List<SocietyManagementWeb.Models.TrialBalanceModel>;
    List<SelectListItem> layoutList = ViewBag.layoutList as List<SelectListItem>;
    List<SelectListItem> pageNoList = ViewBag.pageNoList as List<SelectListItem>;
    var userRight = ViewBag.userRight as SocietyManagementWeb.Models.UserFormRightModel;
    string headerAdd = "";
    string headerList = "";
    string gridAdd = "";
    string gridList = "";
    bool headerAddTrue = false;
    bool headerListTrue = false;

    if (userRight != null && (userRight.IsAdd || userRight.IsEdit) && userRight.IsList)
    {
        headerList = "active";
        gridList = "show active";
        headerAddTrue = true;
    }
    else if (userRight != null && (userRight.IsAdd || userRight.IsEdit))
    {
        headerAdd = "active";
        gridAdd = "show active";
        headerAddTrue = true;
    }
    else if (userRight != null && userRight.IsList)
    {
        headerList = "active";
        gridList = "show active";
        headerAddTrue = true;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card card-primary\">\r\n    <div class=\"card-header\" style=\"font-family:Verdana\">\r\n        <h6> Trial Balance</h6>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div class=\"col-md-12\">\r\n");
#nullable restore
#line 44 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
             if (userRight != null && userRight.IsList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""table-responsive mt-1"" style=""font-family:Verdana;font-size:small;font-display:inherit"">
                <div class=""row mt-3"">
                    <div class=""col-md-2"">
                        <label class=""control-label font-weight-bold customLabel"" style=""font-family:Verdana;font-size:small"">
                            From Date <span class=""required"">*</span>
                        </label>

                        <div class=""form-outline form-white mb-2"">
                            ");
#nullable restore
#line 54 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                       Write(Html.TextBoxFor(x => x.GenFrDate, new { @class = "form-control form-control-lg", @placeholder = "From Date", @tabindex = "1", @style = "font-family: Verdana;font-size:small; height:35px; width: 160px", @required = "required", @type = "date" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-2"">
                        <label class=""control-label font-weight-bold customLabel"" style=""font-family:Verdana;font-size:small"">
                            To Date <span class=""required""></span>
                        </label>
                        <div class=""form-outline form-white mb-2"">
                            ");
#nullable restore
#line 62 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                       Write(Html.TextBoxFor(x => x.GenToDate, new { @class = "form-control form-control-lg", @placeholder = "To Date", @tabindex = "2", @style = "font-family: Verdana;font-size:small; height:35px; width: 160px", @required = "required", @type = "date" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-2"">
                        <label class=""control-label font-weight-bold customLabel"" style=""font-family:Verdana;font-size:small"">
                            Account Group<span class=""required""></span>
                        </label>
                        <div class=""form-outline form-white mb-2"">
                            ");
#nullable restore
#line 70 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                       Write(Html.DropDownListFor(x => x.GroupName, Model.GroupList, "Select", new { @class = "form-control select2 GroupName", @tabindex = "3", @style = "font-family: Verdana;font-size:small; height:35px" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-2"">
                        <label class=""control-label font-weight-bold customLabel"" style=""font-family:Verdana;font-size:small"">
                            Department <span class=""required""></span>
                        </label>
                        <div class=""form-outline form-white mb-2"">
                            ");
#nullable restore
#line 78 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                       Write(Html.DropDownListFor(x => x.Department, Model.DeptList, "Select", new { @class = "form-control select2 Department", @tabindex = "4", @style = "font-family: Verdana;font-size:small; height:35px", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-5 mt-1 text-right"">
                        <button class=""btn btn-primary px-4 text-white"" style=""font-family:Verdana;font-size:medium"" id=""btnSave"" onclick="" loadData();"">
                            View
                        </button>
                        <a href=""/TrialBalance/index"" class=""btn btn-warning px-4 text-dark"" style=""font-family:Verdana;font-size:medium"">
                            Cancel (Esc)
                        </a>
                    </div>
                </div>
                <div class=""col-md-12 col-12 mb-2 mt-2"">
                    <div class=""row"">
                        <div class=""col-md-1 mb-2 float-left"">
                            <select class=""form-control form-control-sm"" onchange=""loadData()"" id=""drpReportPageNoDatable"">
");
#nullable restore
#line 94 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                 for (int i = 0; i < pageNoList.Count; i++)
                                {
                                    string checkedd = "checked";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afa103748116dc7afa988310ff527f7e5cdf53c411138", async() => {
#nullable restore
#line 97 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                                                        Write(pageNoList[i].Text);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "checked", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 97 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
AddHtmlAttributeValue("", 5622, checkedd, 5622, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                           WriteLiteral(pageNoList[i].Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 98 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                    checkedd = string.Empty;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </select>
                        </div>
                        <div class=""col-md-5 col-12"">
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <select class=""form-control select2 drpReportLayout"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afa103748116dc7afa988310ff527f7e5cdf53c414218", async() => {
                WriteLiteral("--Select Layout--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute(";", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 108 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                         if (layoutList != null && layoutList.Count > 0)
                                        {
                                            foreach (var item in layoutList)
                                            {
                                                if (item.Selected)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afa103748116dc7afa988310ff527f7e5cdf53c416415", async() => {
#nullable restore
#line 114 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                                                    Write(item.Text);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 114 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                                WriteLiteral(item.Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 115 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afa103748116dc7afa988310ff527f7e5cdf53c419092", async() => {
#nullable restore
#line 118 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                                           Write(item.Text);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                       WriteLiteral(item.Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 119 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                                }
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </select>\r\n                                </div>\r\n                                <div class=\"col-md-2 col-auto mb-2 custommt-2-3\">\r\n");
#nullable restore
#line 125 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                     if (isAdministrator == 1)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <button class=""btn btn-dark btn-sm text-white"" style=""font-family:Verdana;font-size:medium"" onclick=""window.open('/GridMaster/Index/' + $('.drpReportLayout').val(), '_blank');"">
                                            Edit
                                        </button>
");
#nullable restore
#line 130 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                                <div class=""col-md-4 mb-2 custommt-2-3"">
                                    <button class=""btn btn-primary btn-sm"" id=""btnExportToExcel"">Excel</button>
                                    <button class=""btn btn-primary btn-sm ml-6"" id=""btnExportToPDF"">PDF</button>
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-3""></div>
                        <div class=""col-md-3 col-12 float-right"">
                            <input type=""text"" class=""form-control form-control-sm"" placeholder=""Search"" id=""txtReportSearchDataTable"" />
                        </div>
                    </div>
                </div>
                <div class=""dataTable"">

                </div>
                <div class=""pager float-right""></div>
            </div>
");
#nullable restore
#line 149 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n");
            WriteLiteral(@"
    //function GoToAddTab() {
    //    $('#custom-tabs-three-list-tab').removeClass('active');
    //    $('#custom-tabs-three-add-tab').addClass('active');

    //    $('#custom-tabs-three-list').removeClass('active');
    //    $('#custom-tabs-three-add').addClass('active');
    //    $('#custom-tabs-three-add').addClass('show');
    //    $('#txtDriverNm').focus();
    //}
    //function GoToListTab() {
    //    $('#custom-tabs-three-list-tab').addClass('active');
    //    $('#custom-tabs-three-add-tab').removeClass('active');

    //    $('#custom-tabs-three-list').addClass('active');
    //    $('#custom-tabs-three-list').addClass('show');
    //    $('#custom-tabs-three-add').removeClass('active');
    //    $('#custom-tabs-three-add').removeClass('show');
    //    $('#txtReportSearchDataTable').focus();
    //}
</script>

<script>

    var isRecentCalled = false;


    $(function () {


        var pageIndex = '';
        var pageSize = '';
        var totalRecord =");
            WriteLiteral(" \'\';\r\n        var isDelete = \'");
#nullable restore
#line 216 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                   Write(Html.Raw(userRight.IsDelete));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        var isEdit = \'");
#nullable restore
#line 217 "J:\PROJECTS\JItubhai\Society Management-Git\SocietyManagementWeb\Views\TrialBalance\Index.cshtml"
                 Write(Html.Raw(userRight.IsEdit));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    })

    var timer = null;
    $('#txtReportSearchDataTable').keyup(function (e) {
        if (e.keyCode >= 112 && e.keyCode <= 123) {
            e.preventDefault();
            return false;
        }
        else {
            clearTimeout(timer);

            timer = setTimeout(loadData, 1000)
        }

    });

    function loadData(pageIndex, columnName, sortBy) {
            isRecentCalled = true;
            if (pageIndex == undefined || pageIndex == """" || pageIndex == ""0"" || pageIndex == 0) {
                pageIndex = 1;
            }
            var layoutId = $('.drpReportLayout').val();

            if (!layoutId) {
                $('.drpReportLayout').val($('.drpReportLayout').children('option').eq(1).prop('value'));
                SetSelect2()

            }
            if (!columnName) {
                columnName = '';
            }
            if (!sortBy) {
                sortBy = '';
            }
        var fromDate = $('#GenFrDate').val();
");
            WriteLiteral(@"        var toDate = $('#GenToDate').val();
        var groupName = $('#GroupName').val();
        var department = $('#Department').val();
        if (fromDate == null || fromDate == """" || fromDate == undefined || toDate == null || toDate == """" || toDate == undefined)
        {
            showErrorMessage(""Please select to date and account!"");
            return false;
        }

            $('.dataTable').html();
            $.ajax({
                url: '/TrialBalance/GetReportView',
                type: 'GET',
                data: { pageIndex: pageIndex, pageSize: $('#drpReportPageNoDatable').val(), searchValue: $('#txtReportSearchDataTable').val(), gridMstId: $('.drpReportLayout').val(), columnName: columnName, sortby: sortBy,fromDate : fromDate,toDate : toDate,groupId : groupName,departmentId :department },
                dataType: 'HTML',
                traditional: true, // add this
                success: function (data) {
                    $('.dataTable').html(data);
     ");
            WriteLiteral(@"               setTimeout(function () {
                        isRecentCalled = false;
                    }, 2000)
                },
                failure: function (response) {
                    errorMessage(response);
                }
            });
    }

</script>
<script>
    var isRecentCalledEsc = false;
    (function (code) {
        code(window.jQuery, document, window);
    }(function ($, document, window) {
        $(function () {
            $(window)
                .initKeyboard({ debug: 1 })
                .on('Alt+V', function () {
                    loadData();
                })
        });
    }));

    $('#btnExportToExcel').click(function () {
        var fromDate = $('#GenFrDate').val();
        var toDate = $('#GenToDate').val();
        var groupName = $('#GroupName').val();
        var department = $('#Department').val();
        if (fromDate == null || fromDate == """" || fromDate == undefined || toDate == null || toDate == """" || toDate == undef");
            WriteLiteral(@"ined) {
            showErrorMessage(""Please select to date!"");
            return false;
        }
        window.location.href = ""/TrialBalance/ExportToExcelPDF?gridMstId="" + $('.drpReportLayout').val() + ""&searchValue="" + $('#txtReportSearchDataTable').val() + ""&type=1&toDate="" + toDate + ""&groupId="" + groupName + ""&fromDate="" + fromDate + ""&departmentId="" + department;
    })

    $('#btnExportToPDF').click(function () {
        var fromDate = $('#GenFrDate').val();
        var toDate = $('#GenToDate').val();
        var groupName = $('#GroupName').val();
        var department = $('#Department').val();
        if (fromDate == null || fromDate == """" || fromDate == undefined || toDate == null || toDate == """" || toDate == undefined) {
            showErrorMessage(""Please select to date!"");
            return false;
        }
        window.location.href = ""/TrialBalance/ExportToExcelPDF?gridMstId="" + $('.drpReportLayout').val() + ""&searchValue="" + $('#txtReportSearchDataTable').val() + ""&typ");
            WriteLiteral(@"e=2&toDate="" + toDate + ""&groupId="" + groupName + ""&fromDate="" + fromDate + ""&departmentId="" + department;
    })
</script>
<script>
    function SetSelect2() {
        $("".select2"").select2({
            placeholder: ""---Select---"",
        });
    }

    $(document).ready(function () {

        $("".Department"").select2({
            placeholder: ""---Select---"",
        });

        $("".GroupName"").select2({
            placeholder: ""---Select---"",
        });


        $('.drpReportLayout').select2({
            placeholder: ""---Select---"",
        });
    });
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SocietyManagementWeb.Models.TrialBalanceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
