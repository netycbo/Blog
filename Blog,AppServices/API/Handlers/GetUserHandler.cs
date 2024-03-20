using MediatR;
using Blog_AppServices.API.Domain;

using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Blog.AppServices.API.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUsersRequest, GetUserResponse>
    {
        private readonly IRepository<User> _userRepository;
        public GetUserHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<GetUserResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            var data = users.Select(x => new UserDto()
            {
                Id = x.Id,
                Name = x.Name,
                NickName = x.NickName,
                Email = x.Email,
                IsAdmin = x.IsAdmin,
                JoinedDate = x.RegistrationDate.ToString("dd-MM-yyyy HH:mm")
            }).ToList();

            var response = new GetUserResponse()
            {
                Data = data
            };
            return Task.FromResult(response);
        }
    }
}



