using Blog_AppServices.API.Domain.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Blog_AppServices.API.Domain.Put;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeRoleToAdmin : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChangeRoleToAdmin(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
