#pragma checksum "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\NewSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c686f07d6273580188c8cbf10ab003fbd20a042f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tickets_NewSummary), @"mvc.1.0.view", @"/Views/Tickets/NewSummary.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c686f07d6273580188c8cbf10ab003fbd20a042f", @"/Views/Tickets/NewSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4a88957d73f27b0117f63ade2f5726150099db7", @"/Views/_ViewImports.cshtml")]
    public class Views_Tickets_NewSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\dinosaph\Documents\dinostudy\.net\DinosParking\DinosParking\Views\Tickets\NewSummary.cshtml"
  
    ViewData["Title"] = "NewSummary";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Your summary has been generated.</h1>

<br><br>

<div class=""card"" style=""width: 18rem;"">
  <div class=""card-body"">
    <h5 class=""card-title"">Dino'sParking</h5>
      <ul class=""list-group"">
      <li class=""list-group-item"">Ticket#</li>
      <li class=""list-group-item"">Time In:</li>
      <li class=""list-group-item"">Time Out:</li>
      <li class=""list-group-item"">FEE</li>
      <li class=""list-group-item text-muted"">
          Parking Fee: 10 RON (1st hour) +5 RON (following hours)
      </li>
    </ul>
  </div>
</div>

<br><br>

");
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
