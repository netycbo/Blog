using MediatR;
namespace Blog_AppServices.API.Domain.Get
{
    public class GetUsersRequest : IRequest<GetUserResponse>
    {
        public string Name { get; set; }
    }
}
