using System;

namespace BlogApp.Domain.Exceptions;

public class ForbiddenAccessException(string message) : Exception(message);
