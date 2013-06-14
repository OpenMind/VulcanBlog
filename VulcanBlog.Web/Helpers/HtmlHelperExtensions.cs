﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace VulcanBlog.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Link(this HtmlHelper helper, string text, string href, object htmlAttributes)
        {
            var tag = new TagBuilder("a") {InnerHtml = text};

            if (string.IsNullOrEmpty(href) == false)
                tag.Attributes["href"] = href;

            IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in attributes)
            {
                var val = attribute.Value.ToString();
                if (string.IsNullOrEmpty(val) == false)
                    tag.Attributes[attribute.Key] = val;
            }

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}