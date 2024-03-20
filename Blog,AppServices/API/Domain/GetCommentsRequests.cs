using Blog.DataAccess.Entities;

using Blog_AppServices.API.DTO;
using MediatR;
using System.Collections.Generic;

namespace Blog_AppServices.API.Domain
{
    public class GetCommentsRequests : IRequest<GetCommentsRersponse>
    {
    }
}
