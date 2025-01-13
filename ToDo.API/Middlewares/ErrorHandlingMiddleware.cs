using System.Net;
using ToDo.Domain.Models.Exceptions;

namespace ToDo.API.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception err)
        {
            HttpStatusCode status;
            string message;

            if (err is HttpStatusException httpStatusException)
            {
                status = httpStatusException.StatusCode;
                message = httpStatusException.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = err.Message ?? "An unexpected error occurred";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var errorResponse = new
            {
                StatusCode = (int)status,
                Message = message
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}