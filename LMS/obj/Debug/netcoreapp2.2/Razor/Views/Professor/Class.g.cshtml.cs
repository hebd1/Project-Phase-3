#pragma checksum "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74b7c3af333120f49437ea85095ffcffcb64bb97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_Class), @"mvc.1.0.view", @"/Views/Professor/Class.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/Class.cshtml", typeof(AspNetCore.Views_Professor_Class))]
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
#line 1 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b7c3af333120f49437ea85095ffcffcb64bb97", @"/Views/Professor/Class.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_Class : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
  
  ViewData["Title"] = "Class";
  Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(94, 12, true);
            WriteLiteral("\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(106, 936, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74b7c3af333120f49437ea85095ffcffcb64bb974242", async() => {
                BeginContext(112, 923, true);
                WriteLiteral(@"
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style>
    body {
      font-family: ""Lato"", sans-serif;
    }

    .sidenav {
      /*width: 130px;
      height: 210px;
      position: fixed;
      z-index: 1;
      top: 80px;
      left: 10px;*/
      width: 130px;
      height: 210px;
      position: fixed;
      left: 0;
      right: 0;
      /*margin-left: auto;
      margin-right: auto;*/
      z-index: 1;
      top: 50px;

      background: #eee;
      overflow-x: hidden;
      padding: 8px 0;
    }

      .sidenav a {
        padding: 6px 8px 6px 16px;
        text-decoration: none;
        font-size: 18px;
        color: #2196F3;
        display: block;
      }

        .sidenav a:hover {
          color: #064579;
        }

    .main {
      margin-left: 140px;
      min-height: 200px;
      padding: 0px 10px;
    }
  </style>
");
                EndContext();
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
            EndContext();
            BeginContext(1042, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1044, 1293, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74b7c3af333120f49437ea85095ffcffcb64bb976354", async() => {
                BeginContext(1050, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1085, "\'", 1208, 8);
                WriteAttributeValue("", 1092, "/Professor/Class?subject=", 1092, 25, true);
#line 60 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1117, ViewData["subject"], 1117, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1137, "&num=", 1137, 5, true);
#line 60 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1142, ViewData["num"], 1142, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1158, "&season=", 1158, 8, true);
#line 60 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1166, ViewData["season"], 1166, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1185, "&year=", 1185, 6, true);
#line 60 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1191, ViewData["year"], 1191, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1209, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1233, "\'", 1359, 8);
                WriteAttributeValue("", 1240, "/Professor/Students?subject=", 1240, 28, true);
#line 61 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1268, ViewData["subject"], 1268, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1288, "&num=", 1288, 5, true);
#line 61 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1293, ViewData["num"], 1293, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1309, "&season=", 1309, 8, true);
#line 61 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1317, ViewData["season"], 1317, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1336, "&year=", 1336, 6, true);
#line 61 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1342, ViewData["year"], 1342, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1360, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1381, "\'", 1509, 8);
                WriteAttributeValue("", 1388, "/Professor/Categories?subject=", 1388, 30, true);
#line 62 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1418, ViewData["subject"], 1418, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1438, "&num=", 1438, 5, true);
#line 62 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1443, ViewData["num"], 1443, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1459, "&season=", 1459, 8, true);
#line 62 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1467, ViewData["season"], 1467, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1486, "&year=", 1486, 6, true);
#line 62 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
WriteAttributeValue("", 1492, ViewData["year"], 1492, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1510, 820, true);
                WriteLiteral(@">Assignment Categories</a>
  </div>


  <div class=""main"">
    <h4 id=""classname"">Class</h4>

    <div id=""departmentDiv"" class=""col-md-12"">
    <div class=""panel panel-primary"">
      <div class=""panel-heading"">
        <h3 class=""panel-title"">Assignments</h3>
      </div>
      <div class=""panel-body"">
        <table id=""tblAssignments"" class=""table table-bordered table-striped table-responsive table-hover"">
          <thead>
            <tr>
              <th align=""left"" class=""productth"">Name</th>
              <th align=""left"" class=""productth"">Category</th>
              <th align=""left"" class=""productth"">Due</th>
              <th align=""left"" class=""productth"">Submissions</th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>

  </div>
");
                EndContext();
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
            EndContext();
            BeginContext(2337, 21, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2379, 420, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");


      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
        a.setAttribute(""href"", ""/Professor/Assignment/?subject="" + '");
                EndContext();
                BeginContext(2800, 19, false);
#line 112 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(2819, 15, true);
                WriteLiteral("\' + \"&num=\" + \'");
                EndContext();
                BeginContext(2835, 15, false);
#line 112 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(2850, 18, true);
                WriteLiteral("\' + \"&season=\" + \'");
                EndContext();
                BeginContext(2869, 18, false);
#line 112 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                                                                    Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(2887, 16, true);
                WriteLiteral("\' + \"&year=\" + \'");
                EndContext();
                BeginContext(2904, 16, false);
#line 112 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                                                                                                       Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(2920, 618, true);
                WriteLiteral(@"' + ""&cat="" + item.cname + ""&aname="" + item.aname);
        a.appendChild(document.createTextNode(item.aname));
        td.appendChild(a);
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.cname));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.due));
        tr.appendChild(td);


        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
        a.setAttribute(""href"", ""/Professor/Submissions/?subject="" + '");
                EndContext();
                BeginContext(3539, 19, false);
#line 128 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3558, 15, true);
                WriteLiteral("\' + \"&num=\" + \'");
                EndContext();
                BeginContext(3574, 15, false);
#line 128 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                                   Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3589, 18, true);
                WriteLiteral("\' + \"&season=\" + \'");
                EndContext();
                BeginContext(3608, 18, false);
#line 128 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                                                                     Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3626, 16, true);
                WriteLiteral("\' + \"&year=\" + \'");
                EndContext();
                BeginContext(3643, 16, false);
#line 128 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                                                                                                        Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3659, 328, true);
                WriteLiteral(@"' + ""&cat="" + item.cname + ""&aname="" + item.aname);
        a.appendChild(document.createTextNode(item.submissions));
        td.appendChild(a);
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      classname.innerText = '");
                EndContext();
                BeginContext(3988, 19, false);
#line 142 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                        Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(4007, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(4009, 15, false);
#line 142 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                             Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(4024, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(4026, 18, false);
#line 142 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(4044, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(4046, 16, false);
#line 142 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                                                                                  Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(4062, 121, true);
                WriteLiteral("\';\r\n\r\n      var tbl = document.getElementById(\"tblAssignments\");\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(4184, 51, false);
#line 148 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
         Write(Url.Action("GetAssignmentsInCategory", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(4235, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(4304, 19, false);
#line 151 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(4323, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(4351, 15, false);
#line 152 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(4366, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(4391, 18, false);
#line 153 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(4409, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(4438, 16, false);
#line 154 "D:\Repositories\UofUClasses\CS5530ProjectPhase3\Project-Phase-3\LMS\Views\Professor\Class.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(4454, 467, true);
                WriteLiteral(@"'),
          category: """"},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          PopulateTable(tbl, data);

        },
        error: function (ex) {
          var r = jQuery.parseJSON(response.responseText);
          alert(""Message: "" + r.Message);
          alert(""StackTrace: "" + r.StackTrace);
          alert(""ExceptionType: "" + r.ExceptionType);
        }
        });

        
    }

  </script>

");
                EndContext();
            }
            );
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
