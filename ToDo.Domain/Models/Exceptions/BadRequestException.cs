using System.Net;

namespace ToDo.Domain.Models.Exceptions;

public class BadRequestException(string message) : BaseException(HttpStatusCode.BadRequest, message);