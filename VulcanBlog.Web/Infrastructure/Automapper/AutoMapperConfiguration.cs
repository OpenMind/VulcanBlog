using System;
using System.Web.Mvc;
using AutoMapper;
using VulcanBlog.Web.Infrastructure.Automapper.Profiles;
using VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers;

namespace VulcanBlog.Web.Infrastructure.Automapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<string, MvcHtmlString>().ConvertUsing<MvcHtmlStringConverter>();
            Mapper.CreateMap<Guid, string>().ConvertUsing<GuidToStringConverter>();

            Mapper.CreateMap<DateTimeOffset, DateTime>().ConvertUsing<DateTimeTypeConverter>();


            // TODO: It would make sense to add all of those automatically with an IoC.
            Mapper.AddProfile(new PostViewModelMapperProfile());
            Mapper.AddProfile(new PostsViewModelMapperProfile());
            Mapper.AddProfile(new TagsListViewModelMapperProfile());
            Mapper.AddProfile(new SectionMapperProfile());
            Mapper.AddProfile(new EmailViewModelMapperProfile());

            Mapper.AddProfile(new UserAdminMapperProfile());
            Mapper.AddProfile(new PostsAdminViewModelMapperProfile());
        }
    }
}