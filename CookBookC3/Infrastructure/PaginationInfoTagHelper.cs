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
    [HtmlTargetElement("ul",Attributes="pagination-info")]
    public class PaginationInfoTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PaginationInfo PaginationInfo { get; set; } // -> Attributes="pagination-info"
        public string PageAction { get; set; }
        public string PageOuterClass { get; set; }
        public string PageInnerClass { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-values-")]
        public Dictionary<string, object> PageValues { get; set; }=new Dictionary<string, object>();

        public PaginationInfoTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("li");
            result.AddCssClass(PageOuterClass);

            for (int i = 1; i <= PaginationInfo.PagesCount; i++) 
            {
                TagBuilder tag = new TagBuilder("a");
                tag.AddCssClass(PageInnerClass);
                PageValues["id"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageValues);
                
                tag.InnerHtml.Append(i.ToString());             
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
