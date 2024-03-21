using Blog.DataAccess.Entities;

using Blog_AppServices.API.DTO;
using System.Collections.Generic;
namespace Blog_AppServices.API.Domain
{
    public class GetPostsResponse : ResponseBase<List<NewPostDto>>
    {
    }
}
