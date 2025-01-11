using System.Net;

namespace ToDo.Domain.Domain.Exceptions;

public abstract class BaseException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}