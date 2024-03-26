using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Blog_AppServices.API.ErrorResponse;
using Microsoft.IdentityModel.Tokens;
using Blog_AppServices.API.ErrorHandling;
using System.Net;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, error = x.Value.Errors }));
            }
            var response = await _mediator.Send(request);
            if (response.Error != null)
            {
                return ErrorResponse(response.Error);
            }
            return Ok(response);
        }
        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }
        private static HttpStatusCode GetStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.TooManyRequests:
                    return HttpStatusCode.TooManyRequests;
                default:
                    return HttpStatusCode.BadRequest;

            }
        }
    }
}
