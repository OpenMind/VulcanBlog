using System;

namespace VulcanBlog.Web.Services.RssModels
{
    [Serializable]
    public struct CategoryInfo
    {
        public string description;
        public string htmlUrl;
        public string rssUrl;
        public string title;
        public string categoryid;
    }
}