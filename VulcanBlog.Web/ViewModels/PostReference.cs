﻿using VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers;
using VulcanBlog.Web.Infrastructure.Common;

namespace VulcanBlog.Web.ViewModels
{
    public class PostReference
    {
        // if Id is: posts/1024, than domainId will be: 1024
        public string Id { get; set; }
        public string Title { get; set; }

        private int domainId;
        public int DomainId
        {
            get
            {
                if (domainId == 0)
                    domainId = RavenIdResolver.Resolve(Id);
                return domainId;
            }
        }

        private string slug;
        public string Slug
        {
            get { return slug ?? (slug = SlugConverter.TitleToSlug(Title)); }
            set { slug = value; }
        }
    }
}