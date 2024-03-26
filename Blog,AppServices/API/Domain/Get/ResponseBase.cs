using Blog_AppServices.API.ErrorResponse;
namespace Blog_AppServices.API.Domain.Get
{
    public class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; }
    }
}
