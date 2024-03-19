using MediatR;
using Blog_AppServices.API.Domain;
using Blog_AppServices.API.Domain.Models;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
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
            var data = posts.Select(x => new NewPost()
            {
                Id = x.Id,
                Topic = x.Topic
                
            }).ToList();

            var response = new GetPostsResponse()
            {
                Data = data
            };
            return Task.FromResult(response);
        }       
    }
}
   
    

