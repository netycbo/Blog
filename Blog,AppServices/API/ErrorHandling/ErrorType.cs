
namespace Blog_AppServices.API.ErrorHandling
{
    public static class ErrorType
    {
        public const string InternalServerError = "Internal Server Error";
        public const string ValidationError = "Validation Error";
        public const string NotAutehenticated = "Not Authenticated";
        public const string Unauthorized = "Unauthorized";
        public const string NotFound = "Not Found";
        public const string UnsupportedMediaType = "Unsupported Media Type";
        public const string UnsuportedMethod = "Unsupported Method";
        public const string RequestTooLarge = "Request Too Large";
        public const string TooManyRequests = "Too Many Requests";
        public const string ServerError = "Server Error";
        
    }
}
