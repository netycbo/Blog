using MediatR;
using Blog_AppServices.API.Domain;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Blog.AppServices.API.Handlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsRequests, GetPostsResponse>
    {
        private readonly IRepository<NewPost> _postRepository;
        public GetPostsHandler(IRepository<NewPost> postRepository)
        {
            _postRepository = postRepository;
        }
        public Task<GetPostsResponse> Handle(GetPostsRequests request, CancellationToken cancellationToken)
        {
            var posts = _postRepository.GetAll();
            var data = posts.Select(x => new PostDto()
            {
                UserId = x.Id,
                Topic = x.Topic,
                FormattedDate = x.Date.ToString("dd-MM-yyyy HH:mm")
            }).ToList();

            var response = new GetPostsResponse()
            {
                Data = data
            };
            return Task.FromResult(response);
        }       
    }
}
   
    

