﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Areas\Ops\Views\Home\Index.cshtml"
    using Panoptic.Areas.Ops.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Ops/Views/Home/Index.cshtml")]
    public partial class _Areas_Ops_Views_Home_Index_cshtml : System.Web.Mvc.WebViewPage<Panoptic.Areas.Ops.Models.OpsModel>
    {
        
        #line 8 "..\..\Areas\Ops\Views\Home\Index.cshtml"

    internal string StatusToText(ServiceStatus status)
    {
        switch (status)
        {
            case ServiceStatus.Ok:
                return "Ok";
            case ServiceStatus.Warning:
                return "Warning";
            case ServiceStatus.Error:
                return "Error";
            default:
                return "alert-info";
        }
    }

    internal string StatusToCssAlertClass(ServiceStatus status)
    {
        switch (status)
        {
            case ServiceStatus.Ok:
                return "alert-success";
            case ServiceStatus.Warning:
                return "alert-warning";
            case ServiceStatus.Error:
                return "alert-danger";
            default:
                return "Unknown";
        }
    }

        #line default
        #line hidden

        public _Areas_Ops_Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n");


            
            #line 4 "..\..\Areas\Ops\Views\Home\Index.cshtml"
  
    ViewBag.Title = Model.Name;


            
            #line default
            #line hidden
WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n<div class=\"jumbotron\">\r\n    <h1>");


            
            #line 41 "..\..\Areas\Ops\Views\Home\Index.cshtml"
   Write(Html.DisplayFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n    <p class=\"lead\">");


            
            #line 42 "..\..\Areas\Ops\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <h2>Service " +
"status</h2>\r\n        <p>\r\n            The status of the different services.\r\n   " +
"     </p>\r\n\r\n");


            
            #line 51 "..\..\Areas\Ops\Views\Home\Index.cshtml"
         foreach (var environment in Model.EnvironmentStatus)
        {

            
            #line default
            #line hidden
WriteLiteral("            <h3>");


            
            #line 53 "..\..\Areas\Ops\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(model => environment.Name));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n");



WriteLiteral(@"            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
");


            
            #line 62 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                     foreach (var service in environment.Services)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td>");


            
            #line 65 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(model => service.Name));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"alert ");


            
            #line 66 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                                        Write(StatusToCssAlertClass(service.Status));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 66 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                                                                                Write(StatusToText(service.Status));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        </tr>\r\n");


            
            #line 68 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </tbody>\r\n            </table>\r\n");


            
            #line 71 "..\..\Areas\Ops\Views\Home\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <p>");


            
            #line 72 "..\..\Areas\Ops\Views\Home\Index.cshtml"
          Write(Html.ActionLink("More information \u00bb", "Index", "Status", new { area = "ops", environment = environment.Name }, new { @class = "btn btn-default" }));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");



WriteLiteral("            <br />\r\n");


            
            #line 74 "..\..\Areas\Ops\Views\Home\Index.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div class=\"col-md-4\">\r\n        <h2>Outstanding issues</h2>\r\n\r\n  " +
"      <div>\r\n");


            
            #line 80 "..\..\Areas\Ops\Views\Home\Index.cshtml"
             foreach (var issueSet in Model.Issues)
            {

            
            #line default
            #line hidden
WriteLiteral("                <a class=\"btn btn-lg btn-primary\" href=\"\">\r\n                    <" +
"span>");


            
            #line 83 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                     Write(issueSet.Name);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    <h1>");


            
            #line 84 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                   Write(issueSet.Count);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n                </a>\r\n");


            
            #line 86 "..\..\Areas\Ops\Views\Home\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        <h2>News</h2>\r\n\r\n" +
"");


            
            #line 92 "..\..\Areas\Ops\Views\Home\Index.cshtml"
         foreach (var newsItem in Model.NewsItems)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"panel panel-primary\">\r\n                <div class=\"panel-" +
"heading\">\r\n                    <h3 class=\"panel-title\">");


            
            #line 96 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                                       Write(newsItem.Date.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral(": ");


            
            #line 96 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                                                                              Write(newsItem.Summary);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"panel-body\">\r\n        " +
"            ");


            
            #line 99 "..\..\Areas\Ops\Views\Home\Index.cshtml"
               Write(newsItem.Description);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n");


            
            #line 102 "..\..\Areas\Ops\Views\Home\Index.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral(@"
        <h2>Tools</h2>
        <p>
            The different information about the tools that are active.
        </p>

        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th rowspan=""2"">Name</th>
                    <th colspan=""2"">Release</th>
                    <th colspan=""2"">Number of</th>
                </tr>
                <tr>
                    <th>Version</th>
                    <th>Date</th>
                    <th>Releases</th>
                    <th>Commits</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 124 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                 foreach (var release in Model.Releases)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td>");


            
            #line 127 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                       Write(release.Name);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td>");


            
            #line 128 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                       Write(release.Version.ToString(3));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td>");


            
            #line 129 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                       Write(release.Date.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td>10</td>\r\n                        <td>15</td>\r\n" +
"                    </tr>\r\n");


            
            #line 133 "..\..\Areas\Ops\Views\Home\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
