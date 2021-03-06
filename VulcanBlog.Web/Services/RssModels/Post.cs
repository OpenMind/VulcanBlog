﻿using System;
using CookComputing.XmlRpc;

namespace VulcanBlog.Web.Services.RssModels
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        public DateTime? dateCreated;
        public string description;
        public string title;
        public string[] categories;
        public string permalink;
        public object postid;
        public string userid;
        public string wp_slug;
    }
}