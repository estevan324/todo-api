using System.Net;

namespace ToDo.Domain.Domain.Exceptions;

public class NotFoundException(string message) : BaseException(HttpStatusCode.NotFound, message);