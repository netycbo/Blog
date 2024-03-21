using AutoMapper;
using Blog.DataAccess.Entities;
using Blog_AppServices.API.DTO;

namespace Blog_AppServices.Mappings
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comments, CommentsDto>()
                .ForMember(x => x.CommentPosted, o => o.MapFrom(src => src.Date.ToString("dd-MM-yyyy")))
                .ForMember(x => x.Comment, o => o.MapFrom(src=>src.Comment))
                .ForMember(x => x.UserId, o => o.MapFrom(src => src.UserId))
                .ForMember(x => x.PostId, o => o.MapFrom(src => src.PostId));
        }
    }
}
