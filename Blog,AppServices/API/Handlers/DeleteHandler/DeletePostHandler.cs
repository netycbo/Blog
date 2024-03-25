using AutoMapper;
using Blog.DataAccess.CQRS;
using Blog.DataAccess.CQRS.Commands;
using Blog_AppServices.API.Domain.Delete;
using MediatR;
using Blog.DataAccess.Entities;
using Blog_AppServices.API.DTO;

namespace Blog_AppServices.API.Handlers.DeleteHandler
{
    public class DeletePostHandler : IRequestHandler<DeletePostRequest, DeletePostResponse>
    {
        private readonly ICommandsExecutor _commandsExecutor;
        private readonly IMapper _mapper;

        public DeletePostHandler(ICommandsExecutor commandsExecutor, IMapper mapper)
        {
            _commandsExecutor = commandsExecutor;
            _mapper = mapper;
        }
        async Task<DeletePostResponse> IRequestHandler<DeletePostRequest, DeletePostResponse>.Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            var command = new DeletePostCommand
            {
                Parameter = new NewPost { Id = request.Id }
            };
            var result = await _commandsExecutor.Execute(command);
            var response = new DeletePostResponse
            {
                Data = _mapper.Map<NewPostDto>(result)
            };
            return response;

        }
    }
}
