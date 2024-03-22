using MediatR;
using AutoMapper;
using Blog_AppServices.API.Domain.Post;
using Blog_AppServices.API.DTO;
using Blog.DataAccess.CQRS;
using Blog.DataAccess.CQRS.Commands;
using Blog.DataAccess.Entities;


namespace Blog_AppServices.API.Handlers.PostHandlers
{
    public class AddNewPostHandler : IRequestHandler<AddNewPostRequest, AddNewPostResponse>
    {
        private readonly ICommandsExecutor _commandsExecutor;
        private readonly IMapper _mapper;

        public AddNewPostHandler(ICommandsExecutor commandsExecutor, IMapper mapper)
        {
            _commandsExecutor = commandsExecutor;
            _mapper = mapper;
        }

        public async Task<AddNewPostResponse> Handle(AddNewPostRequest request, CancellationToken cancellationToken)
        {
            var newPost = _mapper.Map<NewPost>(request);
            var command = new AddNewPostCommand() { Parameter = newPost };
            var postFromDb = await _commandsExecutor.Execute(command);
            return new AddNewPostResponse()
            {
                Data = _mapper.Map<NewPostDto>(postFromDb)
            };
        }
    }
}
