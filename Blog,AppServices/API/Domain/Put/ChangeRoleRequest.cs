using MediatR;
namespace Blog_AppServices.API.Domain.Put
{
    public class ChangeRoleRequest : IRequest<ChangeRoleResponse>
    {
        public int UserId { get; set; }
    }
}
