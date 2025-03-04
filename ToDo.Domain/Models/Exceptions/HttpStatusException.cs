﻿using System.Net;

namespace ToDo.Domain.Models.Exceptions;

public abstract class HttpStatusException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}