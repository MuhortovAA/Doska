using Doska.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Infrastructure
{
    [HtmlTargetElement("ul", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public string PageController { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassPagination { get; set; }

        public string PageClassItem { get; set; }
        public string PageClassLink { get; set; }


        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("ul");
            result.AddCssClass(PageClassPagination);
            //li Previous
            TagBuilder taglip = new TagBuilder("li");
            taglip.AddCssClass(PageClassItem);
            TagBuilder tagap = new TagBuilder("a");
            tagap.AddCssClass(PageClassLink);
            tagap.InnerHtml.Append("<");
            taglip.InnerHtml.AppendHtml(tagap);
            result.InnerHtml.AppendHtml(taglip);
            //li
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tagli = new TagBuilder("li");
                tagli.AddCssClass(PageClassItem);

                TagBuilder taga = new TagBuilder("a");
                taga.Attributes["href"] = urlHelper.Action(PageAction, PageController, new { pageid = i });
                taga.AddCssClass(PageClassLink);
                if (i == PageModel.CurrentPage)
                {
                    tagli.AddCssClass(PageClassSelected);
                }
                taga.InnerHtml.Append(i.ToString());
                tagli.InnerHtml.AppendHtml(taga);
                result.InnerHtml.AppendHtml(tagli);
            }
            //li Next
            TagBuilder taglin = new TagBuilder("li");
            taglin.AddCssClass(PageClassItem);
            TagBuilder tagan = new TagBuilder("a");
            tagan.AddCssClass(PageClassLink);
            tagan.InnerHtml.Append(">");
            taglin.InnerHtml.AppendHtml(tagan);
            //
            result.InnerHtml.AppendHtml(taglin);

            output.Content.AppendHtml(result.InnerHtml);
        }



    }
}
