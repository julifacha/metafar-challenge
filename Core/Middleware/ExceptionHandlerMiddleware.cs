using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Core.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "error during executing {Context}", context.Request.Path.Value);
                var response = context.Response;
                response.ContentType = "application/json";

                // get the response code and message
                var (status, message) = GetResponse(exception);
                response.StatusCode = (int)status;
                await response.WriteAsync(message);
            }
        }

        private (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            int errorCode = 0;
            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case CardBlockedException or InvalidPinException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case InsufficientBalanceException:
                    errorCode = InsufficientBalanceException.ErrorCode;
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            return (code, JsonSerializer.Serialize(new { exception.Message, ErrorCode = errorCode}));
        }
    }
}
