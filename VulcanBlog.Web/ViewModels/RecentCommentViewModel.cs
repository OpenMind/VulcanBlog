﻿namespace VulcanBlog.Web.ViewModels
{
    public class RecentCommentViewModel
    {
        public string CommentId { get; set; }
        public string ShortBody { get; set; }
        public string Author { get; set; }
        public string PostTitle { get; set; }
        public int PostId { get; set; }
        public string PostSlug { get; set; }
    }
}