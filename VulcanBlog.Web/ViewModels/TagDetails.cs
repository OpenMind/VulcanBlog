﻿using VulcanBlog.Web.Infrastructure.Common;

namespace VulcanBlog.Web.ViewModels
{
    public class TagDetails
    {
        public string Name { get; set; }

        private string _slug;
        public string Slug
        {
            get { return _slug ?? (_slug = SlugConverter.TitleToSlug(Name)); }
        }
    }
}