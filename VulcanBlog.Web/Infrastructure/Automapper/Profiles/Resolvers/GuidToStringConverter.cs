using System;
using AutoMapper;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers
{
    public class GuidToStringConverter : TypeConverter<Guid, string>
    {
        protected override string ConvertCore(Guid source)
        {
            return source.ToString("N");
        }
    }
}