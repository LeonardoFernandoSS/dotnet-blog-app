using System;

namespace BlogApp.Domain.Exceptions;

public class DuplicateEntityException(string message) : Exception(message);
