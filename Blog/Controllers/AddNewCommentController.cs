using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Blog_AppServices.API.Domain.Post;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddNewCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddNewComment([FromBody] AddNewCommentRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
       
    }
}
