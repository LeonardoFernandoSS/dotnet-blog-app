using System;

namespace BlogApp.Domain.Events;

public record PostPublishedEvent(Guid PostId);
