using MediatR;
using AutoMapper;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Blog_AppServices.API.Domain.Get;
namespace Blog_AppServices.API.Handlers.GetHandlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsRequests, GetPostsResponse>
    {
        private readonly IRepository<NewPost> _postRepository;
        private readonly IMapper _mapper;
        public GetPostsHandler(IRepository<NewPost> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<GetPostsResponse> Handle(GetPostsRequests request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();
            var mappedData = _mapper.Map<List<NewPostDto>>(posts);

            var response = new GetPostsResponse()
            {
                Data = mappedData
            };
            return response;
        }
    }
}



