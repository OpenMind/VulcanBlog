using System;
using System.Collections.Generic;

namespace VulcanBlog.Web.ViewModels
{
    public class FuturePostsViewModel
    {
        public int TotalCount { get; set; }
        public List<FuturePostViewModel> Posts { get; set; }

        public DateTimeOffset? LastPostDate { get; set; }
    }
}