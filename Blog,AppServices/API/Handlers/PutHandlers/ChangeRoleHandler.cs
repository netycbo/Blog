using MediatR;
using AutoMapper;
using Blog_AppServices.API.Domain.Put;
using Blog_AppServices.API.DTO;
using Blog.DataAccess.CQRS;
using Blog.DataAccess.CQRS.Commands;
using Blog.DataAccess.Entities;

namespace Blog_AppServices.API.Handlers.PutHandlers
{
    internal class ChangeRoleHandler : IRequestHandler<ChangeRoleRequest, ChangeRoleResponse>
    {
        public readonly ICommandsExecutor _context;
        public readonly IMapper _mapper;

        public ChangeRoleHandler(ICommandsExecutor context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ChangeRoleResponse> Handle(ChangeRoleRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateUserToAdminCommand
            {
                Parameter = new User { Id = request.UserId }
            };

            var result = await _context.Execute(command);

            // Tworzymy odpowiedź i ustawiamy w niej dane.
            var response = new ChangeRoleResponse
            {
                Data = _mapper.Map<UserDto>(result) // Zakładając, że ResponseBase<T> ma właściwość 'Data'
            };

            return response;
        }
    }
}
