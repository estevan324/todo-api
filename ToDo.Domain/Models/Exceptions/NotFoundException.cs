using System.Net;

namespace ToDo.Domain.Models.Exceptions;

public class NotFoundException(string message) : BaseException(HttpStatusCode.NotFound, message);