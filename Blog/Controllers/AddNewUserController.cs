using Blog_AppServices.API.Domain.Post;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewUserController : ApiControllerBase
    {
        
        public AddNewUserController(IMediator mediator) : base(mediator)
        {

        }
       
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddNewUser ([FromBody] AddNewUserRequest request)
        {
            return await HandleRequest<AddNewUserRequest, AddNewUserResponse>(request);
        }
    }
}
