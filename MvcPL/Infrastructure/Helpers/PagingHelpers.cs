using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, string updateTargetId,
             string loadingElementId, Func<int, string> pageUrl)
        {
            if (pageInfo == null || pageUrl == null)
            {
                return null;
            }

            StringBuilder result = new StringBuilder();
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder btn = new TagBuilder("a");
                TagBuilder li = new TagBuilder("li");
              
                btn.InnerHtml = i.ToString();

                if (i == pageInfo.PageNumber)
                {
                    li.AddCssClass("active");
                    btn.MergeAttribute("href", "#");
                }
                else
                {
                    btn.MergeAttribute("href", pageUrl(i));
                    btn.MergeAttribute("data-ajax", "true");
                    btn.MergeAttribute("data-ajax-update", "#" + updateTargetId);
                    btn.MergeAttribute("data-ajax-loading", "#" + loadingElementId);
                    btn.MergeAttribute("data-ajax-mode", "replaceWith");
                }
                li.InnerHtml += btn.ToString();

                result.Append(li);
            }
            ul.InnerHtml += result.ToString();
            return MvcHtmlString.Create(ul.ToString());

        }

        public static MvcHtmlString LessonPageLinks(this HtmlHelper html, PageInfo pageInfo, string updateTargetId,
            string loadingElementId, Func<int, string> pageUrl)
        {
            if (pageInfo == null || pageUrl == null)
            {
                return null;
            }

            StringBuilder result = new StringBuilder();
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pager");
            TagBuilder prev = new TagBuilder("li");
            TagBuilder next = new TagBuilder("li");
            TagBuilder prevRef = new TagBuilder("a");
            TagBuilder nextRef = new TagBuilder("a");

            if (pageInfo.PageNumber == 1)
            {
                prev.AddCssClass("disabled");
                prevRef.MergeAttribute("hreF", "#");
            }
            else
            {
                prevRef.MergeAttribute("href", pageUrl(pageInfo.PageNumber - 1));
                prevRef.MergeAttribute("data-ajax", "true");
                prevRef.MergeAttribute("data-ajax-update", "#" + updateTargetId);
                prevRef.MergeAttribute("data-ajax-loading", "#" + loadingElementId);
                prevRef.MergeAttribute("data-ajax-mode", "replace");

            }
            if (pageInfo.PageNumber == pageInfo.TotalPages) // last
            {
                nextRef.MergeAttribute("href", "#");
                next.AddCssClass("disabled");
            }
            else
            {
                nextRef.MergeAttribute("href", pageUrl(pageInfo.PageNumber + 1));
                nextRef.MergeAttribute("data-ajax", "true");
                nextRef.MergeAttribute("data-ajax-update", "#" + updateTargetId);
                nextRef.MergeAttribute("data-ajax-loading", "#" + loadingElementId);
                nextRef.MergeAttribute("data-ajax-mode", "replace");
            }

            prevRef.InnerHtml += "&larr; Back";
            nextRef.InnerHtml += "Next  &rarr;";

            //prev.AddCssClass("previous");
            //next.AddCssClass("next");

            prev.InnerHtml += prevRef.ToString();
            next.InnerHtml += nextRef.ToString();

            result.Append(prev);
            result.Append(next);
            ul.InnerHtml += result.ToString();
            return MvcHtmlString.Create(ul.ToString());
        }
//        <ul class="pager">
//  <li class="previous disabled"><a href = "#" > &larr; Older</a></li>
//  <li class="next"><a href = "#" > Newer & rarr;</a></li>
//</ul>
    }

}