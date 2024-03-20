using MediatR;
using Blog_AppServices.API.Domain;
using AutoMapper;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Blog.AppServices.API.Handlers
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsRequests, GetCommentsRersponse>
    {
        private readonly IRepository<Comments> _commentsRepository;
        private readonly IMapper _mapper;
        public GetCommentsHandler(IRepository<Comments> commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }
        public Task<GetCommentsRersponse> Handle(GetCommentsRequests request, CancellationToken cancellationToken)
        {
            var comments = _commentsRepository.GetAll();
           var mappedData = _mapper.Map<List<CommentsDto>>(comments);

            var response = new GetCommentsRersponse()
            {
                Data = mappedData
            };
            return Task.FromResult(response);
        }
    }
}



