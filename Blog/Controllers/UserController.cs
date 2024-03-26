using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Blog_AppServices.API.Domain.Get;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
       
        public UserController(IMediator mediator) : base(mediator)
        {

        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
