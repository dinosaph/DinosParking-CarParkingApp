#pragma checksum "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\Scan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c12dff25847c699b4606aff6b7b6d850f780a133"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tickets_Scan), @"mvc.1.0.view", @"/Views/Tickets/Scan.cshtml")]
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
#line 1 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\_ViewImports.cshtml"
using DinosParking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\_ViewImports.cshtml"
using DinosParking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c12dff25847c699b4606aff6b7b6d850f780a133", @"/Views/Tickets/Scan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4a88957d73f27b0117f63ade2f5726150099db7", @"/Views/_ViewImports.cshtml")]
    public class Views_Tickets_Scan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DinosParking.Models.Ticket>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\Scan.cshtml"
  
    ViewData["Title"] = "Scan";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Scan Parking Ticket</h1>\r\n<p></p>\r\n\r\n<br><br>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\Scan.cshtml"
 using (Html.BeginForm("ScanTicket", "Tickets", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!--<div class=""form-group"">
    <label for=""inputBarcode"">Barcode</label>
    <input type=""text"" class=""form-control"" id=""inputBarcode"" placeholder=""Enter ticket barcode"">
    <small id=""ticketHelp"" class=""form-text text-muted"">Check your parking ticket barcode.</small>
    </div>
    <button type=""submit"" class=""btn btn-primary"" onclick=""location.href='");
#nullable restore
#line 19 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\Scan.cshtml"
                                                                     Write(Url.Action("ScanTicket","Tickets"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\">Scan</button>-->\r\n");
#nullable restore
#line 20 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\Scan.cshtml"
Write(Html.TextBoxFor(m => m.BarCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"submit\" value=\"Scan\"/>\r\n");
#nullable restore
#line 22 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\Scan.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br><br>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DinosParking.Models.Ticket> Html { get; private set; }
    }
}
#pragma warning restore 1591