using AutoMapper;
using Blog.DataAccess.Entities;
using Blog_AppServices.API.DTO;
namespace Blog_AppServices.Mappings
{
    internal class NewPostProfile : Profile
    {
        public NewPostProfile()
        {
            CreateMap<NewPost, PostDto>()
                .ForMember(x=>x.PostedDate, o=>o.MapFrom(src=>src.Date.ToString("dd-MM-yyyy")));
        }
    }
}
