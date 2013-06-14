using System;
using AutoMapper;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers
{
    public class DateTimeTypeConverter : TypeConverter<DateTimeOffset, DateTime>
    {
        protected override DateTime ConvertCore(DateTimeOffset source)
        {
            return source.DateTime;
        }
    }
}