using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Blog_AppServices.API.Domain;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetUsersRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
