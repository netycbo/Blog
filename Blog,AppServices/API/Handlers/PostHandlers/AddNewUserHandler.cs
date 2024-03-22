using MediatR;
using AutoMapper;
using Blog_AppServices.API.Domain.Post;
using Blog_AppServices.API.DTO;
using Blog.DataAccess.CQRS;
using Blog.DataAccess.CQRS.Commands;
using Blog.DataAccess.Entities;


namespace Blog_AppServices.API.Handlers.PostHandlers
{
    public class AddNewUserHandler : IRequestHandler<AddNewUserRequest, AddNewUserResponse>
    {
        private readonly ICommandsExecutor _commandsExecutor;
        private readonly IMapper _mapper;
        public AddNewUserHandler(ICommandsExecutor commandsExecutor, IMapper mapper)
        {
            _commandsExecutor = commandsExecutor;
            _mapper = mapper;
        }
        public async Task<AddNewUserResponse> Handle(AddNewUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request);
            var command = new AddNewUserCommand() { Parameter = newUser };
            var userFromDb=   await _commandsExecutor.Execute(command);
            return new AddNewUserResponse()
            {
                Data = _mapper.Map<UserDto>(userFromDb)
            };
        }
    }
}
