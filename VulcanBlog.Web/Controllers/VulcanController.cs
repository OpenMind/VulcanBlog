﻿using System;
using System.Web.Mvc;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Serialization;
using VulcanBlog.Web.Helpers.Results;
using VulcanBlog.Web.Internals.Controllers;
using VulcanBlog.Web.Models;

namespace VulcanBlog.Web.Controllers
{
    public abstract class VulcanController : RavenController
    {
        public const int DefaultPage = 1;
        public const int PageSize = 25;

        private BlogConfig blogConfig;
        public BlogConfig BlogConfig
        {
            get
            {
                if (blogConfig == null)
                {
                    using (RavenSession.Advanced.DocumentStore.AggressivelyCacheFor(TimeSpan.FromMinutes(5)))
                    {
                        blogConfig = RavenSession.Load<BlogConfig>("Blog/Config");
                    }

                    if (blogConfig == null && "welcome".Equals((string)RouteData.Values["controller"], StringComparison.OrdinalIgnoreCase) == false) // first launch
                    {
                        HttpContext.Response.Redirect("~/welcome", true);
                    }
                }
                return blogConfig;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ViewBag.BlogConfig = BlogConfig;
        }

        protected int CurrentPage
        {
            get
            {
                var s = Request.QueryString["page"];
                int result;
                if (int.TryParse(s, out result))
                    return Math.Max(DefaultPage, result);
                return DefaultPage;
            }
        }

        protected new JsonNetResult Json(object data)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return new JsonNetResult(data, settings);
        }
    }
}