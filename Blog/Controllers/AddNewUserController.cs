using Blog_AppServices.API.Domain.Post;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddNewUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddNewUser ([FromBody] AddNewUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
