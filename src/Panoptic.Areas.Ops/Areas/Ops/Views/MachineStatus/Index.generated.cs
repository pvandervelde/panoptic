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
    
    #line 1 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
    using Panoptic.Areas.Ops.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Ops/Views/MachineStatus/Index.cshtml")]
    public partial class _Areas_Ops_Views_MachineStatus_Index_cshtml : System.Web.Mvc.WebViewPage<Panoptic.Areas.Ops.Models.MachineStatusModel>
    {
        
        #line 8 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"

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

        public _Areas_Ops_Views_MachineStatus_Index_cshtml()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n");


            
            #line 4 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
  
    ViewBag.Title = Model.Name;


            
            #line default
            #line hidden
WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n<div class=\"jumbotron\">\r\n    <h1>");


            
            #line 41 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
   Write(Html.DisplayFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n    <p class=\"lead\">");


            
            #line 42 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
               Write(Html.DisplayFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral(@"</p>
</div>
<div>
    <div>
        <h2>Current status</h2>
        <p>
            The current status of the machines.
        </p>
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Status</th>
                    <th colspan=""2"">CPU</th>
                    <th colspan=""3"">Memory</th>
                    <th>Disks</th>
                    <th>Issues</th>
                </tr>
                <tr>
                    <th></th>
                    <th></th>
                    <th>Current</th>
                    <th>History</th>
                    <th>In use</th>
                    <th>Total</th>
                    <th>&#37; in use</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>");


            
            #line 74 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                   Write(Html.DisplayFor(model => Model.Name));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td class=\"alert ");


            
            #line 75 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                                Write(StatusToCssAlertClass(Model.Status));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 75 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                                                                      Write(StatusToText(Model.Status));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");


            
            #line 76 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                   Write(Html.DisplayFor(model => Model.CpuPercentage));

            
            #line default
            #line hidden
WriteLiteral(" &#37;</td>\r\n                    <td>CPU history ...</td>\r\n                    <t" +
"d>");


            
            #line 78 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                   Write(Html.DisplayFor(model => Model.MemoryInUseInGb));

            
            #line default
            #line hidden
WriteLiteral(" Gb</td>\r\n                    <td>");


            
            #line 79 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                   Write(Html.DisplayFor(model => Model.MemoryTotalInGb));

            
            #line default
            #line hidden
WriteLiteral(" Gb</td>\r\n                    <td>");


            
            #line 80 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                   Write(Html.DisplayFor(model => Model.MemoryInUsePercentage));

            
            #line default
            #line hidden
WriteLiteral(" &#37;</td>\r\n                    <td>disks ....</td>\r\n                    <td>");


            
            #line 82 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                   Write(Html.DisplayFor(model => Model.Notification));

            
            #line default
            #line hidden
WriteLiteral(@"</td>
                </tr>
            </tbody>
        </table>

        <h2>Logs</h2>
        <p>
            The latest logs coming from the machine.
        </p>

        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Type</th>
                    <th>Log</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 101 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                 foreach (var log in Model.Logs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td>");


            
            #line 104 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                       Write(Html.DisplayFor(model => log.Date));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td>");


            
            #line 105 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                       Write(Html.DisplayFor(model => log.Type));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td>");


            
            #line 106 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                       Write(Html.DisplayFor(model => log.Text));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    </tr>\r\n");


            
            #line 108 "..\..\Areas\Ops\Views\MachineStatus\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
