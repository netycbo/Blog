using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
using MediatR;
using Blog_AppServices.API.Domain.Get;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetPostsRequests request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);    
        }
    }
}
