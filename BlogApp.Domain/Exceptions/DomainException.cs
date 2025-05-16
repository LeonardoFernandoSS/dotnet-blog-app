using System;

namespace BlogApp.Domain.Exceptions;

public class DomainException(string message) : Exception(message);
