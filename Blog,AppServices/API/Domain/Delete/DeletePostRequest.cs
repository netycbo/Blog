using MediatR;

namespace Blog_AppServices.API.Domain.Delete
{
    public class DeletePostRequest : IRequest<DeletePostResponse>
    {
        public int Id { get; set; }
    }
}
