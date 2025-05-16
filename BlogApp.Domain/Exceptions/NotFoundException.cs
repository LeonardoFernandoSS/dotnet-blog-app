using System;
using BlogApp.Domain.Common;

namespace BlogApp.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string nameof, object id) : base(Messages.Exception.NotFound(nameof, id))
    {
    }
}
