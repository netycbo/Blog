using MediatR;
using AutoMapper;
using Blog_AppServices.API.Domain.Post;
using Blog_AppServices.API.DTO;
using Blog.DataAccess.CQRS;
using Blog.DataAccess.CQRS.Commands;
using Blog.DataAccess.Entities;

namespace Blog_AppServices.API.Handlers.PostHandlers
{
    internal class AddNewCommentHandler : IRequestHandler<AddNewCommentRequest, AddNewCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandsExecutor _commandsExecutor;

        public AddNewCommentHandler(ICommandsExecutor commandsExecutor, IMapper mapper)
        {
            _commandsExecutor = commandsExecutor;
            _mapper = mapper;
        }

        public async Task<AddNewCommentResponse> Handle(AddNewCommentRequest request, CancellationToken cancellationToken)
        {
            var newComment = _mapper.Map<Comments>(request);
            var command = new AddNewCommentCommand() { Parameter = newComment };
            var commentFromDb = await _commandsExecutor.Execute(command);
            return new AddNewCommentResponse();
        }

    }
}
