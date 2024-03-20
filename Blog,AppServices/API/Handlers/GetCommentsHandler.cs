using MediatR;
using Blog_AppServices.API.Domain;

using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Blog.AppServices.API.Handlers
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsRequests, GetCommentsRersponse>
    {
        private readonly IRepository<Comments> _commentsRepository;
        public GetCommentsHandler(IRepository<Comments> commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        public Task<GetCommentsRersponse> Handle(GetCommentsRequests request, CancellationToken cancellationToken)
        {
            var comments = _commentsRepository.GetAll();
            var data = comments.Select(x => new CommentsDto()
            {
                UserId = x.UserId,
                Comment = x.Comment,
                PostId = x.PostId,
                FormattedDate = x.Date.ToString("dd-MM-yyyy HH:mm")
            }).ToList();

            var response = new GetCommentsRersponse()
            {
                Data = data
            };
            return Task.FromResult(response);
        }
    }
}



