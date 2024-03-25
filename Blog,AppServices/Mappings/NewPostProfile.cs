using AutoMapper;
using Blog.DataAccess.Entities;
using Blog_AppServices.API.DTO;
using Blog_AppServices.API.Domain.Post;
using Blog_AppServices.API.Domain.Delete;
namespace Blog_AppServices.Mappings
{
    public class NewPostProfile : Profile
    {
        public NewPostProfile()
        {
            CreateMap<NewPost, NewPostDto>()
                .ForMember(x=>x.PostedDate, o=>o.MapFrom(src=>src.Date.ToString("dd-MM-yyyy")))
                .ForMember(x=>x.UserId, o=>o.MapFrom(src=>src.UserId))
                .ForMember(x=>x.Topic, o=>o.MapFrom(src=>src.Topic));

            CreateMap<AddNewPostRequest, NewPost>();
            CreateMap<DeletePostResponse, NewPostDto>();
        }
    }
}
