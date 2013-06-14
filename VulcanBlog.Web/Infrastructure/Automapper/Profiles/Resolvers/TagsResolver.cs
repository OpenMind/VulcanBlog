using System;
using System.Collections.Generic;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers
{
    public class TagsResolver
    {
        private const string TagsSeparator = "|";

        public static string ResolveTags(ICollection<string> tags)
        {
            return string.Join(TagsSeparator, tags);
        }

        public static ICollection<string> ResolveTagsInput(string tags)
        {
            return tags.Split(new[] { TagsSeparator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}