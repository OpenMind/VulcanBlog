using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VulcanBlog.Web.Internals.Models
{
    public enum DynamicContentType
    {
        Markdown,
        Html,
        Video,
        HttpRedirection,
    }

    public interface IDynamicContent
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        string Body { get; set; }
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        DynamicContentType ContentType { get; set; }
    }

    public interface ISearchable
    {
        string Slug { get; set; }
        string Title { get; set; }
        string Content { get; set; }
    }
}