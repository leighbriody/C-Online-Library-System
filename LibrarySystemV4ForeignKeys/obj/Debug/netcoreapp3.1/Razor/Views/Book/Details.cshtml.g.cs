#pragma checksum "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c361db2b7037ca23ee76f53b41dd1874215764b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_Details), @"mvc.1.0.view", @"/Views/Book/Details.cshtml")]
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
#line 1 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\_ViewImports.cshtml"
using LibrarySystemV4ForeignKeys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\_ViewImports.cshtml"
using LibrarySystemV4ForeignKeys.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c361db2b7037ca23ee76f53b41dd1874215764b7", @"/Views/Book/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c090979f5badc39492be86498a738c674316074", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LibrarySystemV4ForeignKeys.Models.Book>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- ======= Hero Section ======= -->
<section id=""hero"" class=""d-flex align-items-center"">
    <div class=""container"" data-aos=""zoom-out"" data-aos-delay=""100"">
        <h1>All  <span>Books</span></h1>
        <h2>Below is  all books currently in the library</h2>
        <div class=""d-flex"">

        </div>
    </div>
</section><!-- End Hero -->


<main id=""main"">

    <!-- ======= Team Section ======= -->
    <section id=""team"" class=""team section-bg"">
        <div class=""container"" data-aos=""fade-up"">

            <div class=""section-title"">

                <h3>Book<span>Details</span></h3>
                <p>
                    Here is the book details
                </p>


            </div>

            <div class=""row"">

               

                    <div class=""col-lg-3 col-md-6 d-flex align-items-stretch"" data-aos=""fade-up"" data-aos-delay=""400"">
                        <div class=""member"">
                            <div class=""member-img"">
             ");
            WriteLiteral("                   ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c361db2b7037ca23ee76f53b41dd1874215764b75221", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                               WriteLiteral("~/image/"+Model.ImageName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 42 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"member-info\">\r\n                                <h4>Name : ");
#nullable restore
#line 46 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                                      Write(Model.bookName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                                <span>Author : ");
#nullable restore
#line 47 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                                          Write(Model.author);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                <span>Description : ");
#nullable restore
#line 48 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                                               Write(Model.description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                <span>Genre : ");
#nullable restore
#line 49 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                                         Write(Model.genreType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                <span>Quantity : ");
#nullable restore
#line 50 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                                            Write(Model.quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                <span> OverFee : ");
#nullable restore
#line 51 "C:\Final Library System - Leigh and Osama\LibrarySystemV4ForeignKeys\Views\Book\Details.cshtml"
                                            Write(Model.overdueFeePerDay);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n                \r\n\r\n            </div>\r\n    </section><!-- End Team Section -->\r\n\r\n\r\n\r\n</main><!-- End #main -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LibrarySystemV4ForeignKeys.Models.Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
