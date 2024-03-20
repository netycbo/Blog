using AutoMapper;
using Blog.DataAccess.Entities;
using Blog_AppServices.API.DTO;

namespace Blog_AppServices.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.JoinedDate, o => o.MapFrom(src => src.RegistrationDate.ToString("dd-MM-yyyy")));
        }
    }
}
