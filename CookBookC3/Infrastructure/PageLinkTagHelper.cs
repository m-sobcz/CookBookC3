using CookBookC3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Infrastructure
{
    [HtmlTargetElement("ul",Attributes="page-info")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageInfo PageInfo { get; set; } // !! takie jak nazwa atrybuty ?
        public string PageAction { get; set; }
        public string PageOuterClass { get; set; }
        public string PageInnerClass { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("li");
            result.AddCssClass(PageOuterClass);

            for (int i = 1; i <= PageInfo.PagesCount; i++) 
            {
                TagBuilder tag = new TagBuilder("a");
                tag.AddCssClass(PageInnerClass);
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { currentPage = i });
                
                tag.InnerHtml.Append(i.ToString());             
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
