﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VulcanBlog.Web.Controllers;

namespace VulcanBlog.Web.ViewModels
{
    public class PostsViewModel
    {
        public bool HasNextPage
        {
            get { return CurrentPage * VulcanController.PageSize < PostsCount; }
        }

        public bool HasPrevPage
        {
            get { return CurrentPage * VulcanController.PageSize > VulcanController.PageSize * VulcanController.DefaultPage; }
        }

        public int CurrentPage { get; set; }
        public int PostsCount { get; set; }

        public IList<PostSummary> Posts { get; set; }

        public class PostSummary
        {
            public int Id { get; set; }
            public MvcHtmlString Title { get; set; }
            public string Slug { get; set; }
            public MvcHtmlString Body { get; set; }
            public ICollection<TagDetails> Tags { get; set; }
            public DateTimeOffset CreatedAt { get; set; }
            public DateTimeOffset PublishedAt { get; set; }
            public int CommentsCount { get; set; }
            public UserDetails Author { get; set; }

            public class UserDetails
            {
                public string TwitterNick { get; set; }
                public string RelatedTwitterNick { get; set; }
                public string RelatedTwitNickDes { get; set; }
            }
        }
    }
}