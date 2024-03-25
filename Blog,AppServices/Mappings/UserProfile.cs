using AutoMapper;
using Blog.DataAccess.Entities;
using Blog_AppServices.API.Domain.Post;
using Blog_AppServices.API.Domain.Put;
using Blog_AppServices.API.DTO;

namespace Blog_AppServices.Mappings
{
    public class UserProfile : Profile
    {
        
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.JoinedDate, o => o.MapFrom(src => src.RegistrationDate.ToString("dd-MM-yyyy")))
                .ForMember(x => x.Id, o => o.MapFrom(src => src.Id))
                .ForMember(x => x.Email, o => o.MapFrom(src => src.Email))
                .ForMember(x => x.NickName, o => o.MapFrom(src => src.NickName))
                .ForMember(x => x.Role, o => o.MapFrom(src => src.IsAdmin ? "Admin" : "User"))
                .ForMember(x=> x.Name, o=>o.MapFrom(src=>src.Name));

            CreateMap<AddNewUserRequest, User>();
            CreateMap<ChangeRoleResponse, User>();


        }

    }
}
