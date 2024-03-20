using MediatR;
using Blog_AppServices.API.Domain;

using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
namespace Blog.AppServices.API.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUsersRequest, GetUserResponse>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public GetUserHandler(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Task<GetUserResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
           var mappedUser = _mapper.Map<List<UserDto>>(users);
            var response = new GetUserResponse()
            {
                Data = mappedUser
            };
            return Task.FromResult(response);
        }
    }
}



