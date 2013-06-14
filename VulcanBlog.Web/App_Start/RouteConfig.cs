using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VulcanBlog.Web.Internals.Extensions;

namespace VulcanBlog.Web
{
    public class RouteConfig
    {
        private const string MatchPositiveInteger = @"\d{1,10}";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            Syndication(routes);

            Posts(routes);
            LegacyPost(routes);
            PostDetails(routes);

            Search(routes);
            Css(routes);

            routes.MapRouteLowerCase("Default",
                "{controller}/{action}",
                new { controller = "Posts", action = "Index" },
                new[] { "VulcanBlog.Web.Controllers" }
                );

            routes.MapRouteLowerCase("homepage",
               "",
               new { controller = "Posts", action = "Index" },
               new[] { "VulcanBlog.Web.Controllers" }
               );
        }

        private static void Css(RouteCollection routes)
        {
            routes.MapRouteLowerCase("CssController",
                "css",
                new { controller = "Css", action = "Merge" },
                new[] { "VulcanBlog.Web.Controllers" }
                );
        }

        private static void Search(RouteCollection routes)
        {
            routes.MapRouteLowerCase("SearchController-GoogleCse",
               "search/google_cse.xml",
               new { controller = "Search", action = "GoogleCse" },
               new[] { "VulcanBlog.Web.Controllers" }
               );

            routes.MapRouteLowerCase("SearchController",
               "search/{action}",
               new { controller = "Search", action = "SearchResult" },
               new { action = "SearchResult" },
               new[] { "VulcanBlog.Web.Controllers" }
               );
        }

        private static void Posts(RouteCollection routes)
        {
            routes.MapRouteLowerCase("PostsByTag",
                "tags/{slug}",
                new { controller = "Posts", action = "Tag" },
                new[] { "VulcanBlog.Web.Controllers" }
                );

            routes.MapRouteLowerCase("PostsByYearMonthDay",
                "archive/{year}/{month}/{day}",
                new { controller = "Posts", action = "Archive" },
                new { Year = MatchPositiveInteger, Month = MatchPositiveInteger, Day = MatchPositiveInteger },
                new[] { "VulcanBlog.Web.Controllers" }
                );

            routes.MapRouteLowerCase("PostsByYearMonth",
                "archive/{year}/{month}",
                new { controller = "Posts", action = "Archive" },
                new { Year = MatchPositiveInteger, Month = MatchPositiveInteger },
                new[] { "VulcanBlog.Web.Controllers" }
                );

            routes.MapRouteLowerCase("PostsByYear",
                "archive/{year}",
                new { controller = "Posts", action = "Archive" },
                new { Year = MatchPositiveInteger },
                new[] { "VulcanBlog.Web.Controllers" }
                );
        }

        private static void LegacyPost(RouteCollection routes)
        {
            routes.MapRouteLowerCase("RedirectLegacyPostUrl",
                "archive/{year}/{month}/{day}/{slug}.aspx",
                new { controller = "LegacyPost", action = "RedirectLegacyPost" },
                new { Year = MatchPositiveInteger, Month = MatchPositiveInteger, Day = MatchPositiveInteger },
                new[] { "VulcanBlog.Web.Controllers" }
                );

            routes.MapRouteLowerCase("RedirectLegacyArchive",
               "archive/{year}/{month}/{day}.aspx",
               new { controller = "LegacyPost", action = "RedirectLegacyArchive" },
               new { Year = MatchPositiveInteger, Month = MatchPositiveInteger, Day = MatchPositiveInteger },
               new[] { "VulcanBlog.Web.Controllers" }
               );
        }

        private static void PostDetails(RouteCollection routes)
        {
            routes.MapRouteLowerCase("PostDetailsController-Comment",
                "{id}/comment",
                new { controller = "PostDetails", action = "Comment" },
                new { httpMethod = new HttpMethodConstraint("POST"), id = MatchPositiveInteger },
                new[] { "VulcanBlog.Web.Controllers" }
                );

            routes.MapRouteLowerCase("PostDetailsController-Details",
                "{id}/{slug}",
                new { controller = "PostDetails", action = "Details", slug = UrlParameter.Optional },
                new { id = MatchPositiveInteger },
                new[] { "VulcanBlog.Web.Controllers" }
                );
        }

        private static void Syndication(RouteCollection routes)
        {
            routes.MapRouteLowerCase("CommentsRssFeed",
              "rss/comments",
              new { controller = "Syndication", action = "CommentsRss" },
              new[] { "VulcanBlog.Web.Controllers" }
              );

            routes.MapRouteLowerCase("RssFeed",
              "rss/{tag}",
              new { controller = "Syndication", action = "Rss", tag = UrlParameter.Optional },
              new[] { "VulcanBlog.Web.Controllers" }
              );

            routes.MapRouteLowerCase("RsdFeed",
              "rsd",
              new { controller = "Syndication", action = "Rsd" },
              new[] { "VulcanBlog.Web.Controllers" }
              );

            routes.MapRouteLowerCase("RssFeed-LegacyUrl",
              "rss.aspx",
              new { controller = "Syndication", action = "LegacyRss" },
              new[] { "VulcanBlog.Web.Controllers" }
              );
        }

    }
}