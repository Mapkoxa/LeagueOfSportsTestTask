using System;
using System.Text;
using System.Web.Mvc;
using LeagueOfSportsTestTask.Models;

namespace LeagueOfSportsTestTask.Helpers
{
    public static class PaginationHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagerInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                if (i >= pageInfo.PageNumber - 5 || i <= pageInfo.PageNumber + 5)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    if (i == pageInfo.PageNumber)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    result.Append(tag);
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}