#pragma checksum "/Users/macbook/Projects/NeuralNetwork/NeuralNetwork/Views/Shared/_SideBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8573b17b54abd494d40c3cd173633d1c1f565a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SideBar), @"mvc.1.0.view", @"/Views/Shared/_SideBar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_SideBar.cshtml", typeof(AspNetCore.Views_Shared__SideBar))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8573b17b54abd494d40c3cd173633d1c1f565a9", @"/Views/Shared/_SideBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SideBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(11, 23, true);
            WriteLiteral("<div class=\"col-lg-2\">\n");
            EndContext();
#line 3 "/Users/macbook/Projects/NeuralNetwork/NeuralNetwork/Views/Shared/_SideBar.cshtml"
     for(var item = 0; item < Model; item++)
    {

#line default
#line hidden
            BeginContext(85, 54, true);
            WriteLiteral("        <div class=\"sidebar__item\">\n            <input");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 139, "\"", 155, 3);
            WriteAttributeValue("", 146, "In[", 146, 3, true);
#line 6 "/Users/macbook/Projects/NeuralNetwork/NeuralNetwork/Views/Shared/_SideBar.cshtml"
WriteAttributeValue("", 149, item, 149, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 154, "]", 154, 1, true);
            EndWriteAttribute();
            BeginContext(156, 56, true);
            WriteLiteral(" type=\"text\" class=\"sidebar__item_in\" />\n        </div>\n");
            EndContext();
#line 8 "/Users/macbook/Projects/NeuralNetwork/NeuralNetwork/Views/Shared/_SideBar.cshtml"
    }

#line default
#line hidden
            BeginContext(218, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
