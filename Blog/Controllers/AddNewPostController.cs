using Microsoft.AspNetCore.Http;
using Blog_AppServices.API.Domain.Post;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewPostController : ControllerBase
    {
        private readonly IMediator _mediator; 
        public AddNewPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddNewPost([FromBody] AddNewPostRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
