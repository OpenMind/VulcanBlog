namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers
{
    public class UrlResolver
    {
        public static string Resolve(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            if (url.StartsWith("http://") || url.StartsWith("https://"))
                return url;

            return string.Concat("http://", url);
        }
    }
}