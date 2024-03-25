using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Blog_AppServices.API.Domain.Delete;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletePostController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DeletePostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
