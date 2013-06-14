using AutoMapper;
using VulcanBlog.Web.Infrastructure.Indexes;
using VulcanBlog.Web.ViewModels;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles
{
    public class TagsListViewModelMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Tags_Count.ReduceResult, TagsListViewModel>()
                ;
        }
    }
}