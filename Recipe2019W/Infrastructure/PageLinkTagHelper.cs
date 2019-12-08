using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Recipe2019W.Models.ViewModels;

namespace Recipe2019W.Infrastructure
{
    // This class is the Tag Helper Class for Page Link
    //Which tag helper this class builds, and what attributes are contained
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        //This property holds the current HTTP context
        [ViewContext]
        //Will not require HTML Attribute
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        // The Model providing to the tag helper
        public PagingInfo PageModel { get; set; }
        // Stores which Controller action will be linked
        public string PageAction { get; set; }

        // CSS Classes Related to Tag Helper
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Building the tag
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            // A Div block that holds all the link to the pages
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction,
                    new { recipePage = i });
                // Add CSS Classes
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
