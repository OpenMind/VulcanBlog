using AutoMapper;
using VulcanBlog.Web.Infrastructure.Automapper.Profiles.Resolvers;
using VulcanBlog.Web.Models;
using VulcanBlog.Web.ViewModels;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles
{
    public class UserAdminMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, UserSummeryViewModel>()
                  .ForMember(x => x.Id, o => o.MapFrom(m => RavenIdResolver.Resolve(m.Id)))
                ;

            Mapper.CreateMap<UserInput, User>()
                  .ForMember(x => x.Id, o => o.Ignore());

            Mapper.CreateMap<User, UserInput>()
                  .ForMember(x => x.Id, o => o.MapFrom(m => RavenIdResolver.Resolve(m.Id)))
                ;
        }
    }
}