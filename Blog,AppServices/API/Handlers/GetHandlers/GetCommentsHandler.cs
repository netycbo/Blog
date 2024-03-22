using MediatR;
using AutoMapper;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Blog_AppServices.API.Domain.Get;
namespace Blog_AppServices.API.Handlers.GetHandlers
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
        public async Task<GetCommentsRersponse> Handle(GetCommentsRequests request, CancellationToken cancellationToken)
        {
            var comments = await _commentsRepository.GetAll();
            var mappedData = _mapper.Map<List<CommentsDto>>(comments);

            var response = new GetCommentsRersponse()
            {
                Data = mappedData
            };
            return response;
        }
    }
}



