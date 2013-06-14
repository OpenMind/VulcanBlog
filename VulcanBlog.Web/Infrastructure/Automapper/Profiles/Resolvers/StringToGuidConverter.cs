using System;
using AutoMapper;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers
{
    public class StringToGuidConverter : TypeConverter<string, Guid>
    {
        protected override Guid ConvertCore(string source)
        {
            Guid guid;
            if (Guid.TryParse(source, out guid) == false)
                return Guid.Empty;
            return guid;
        }
    }
}