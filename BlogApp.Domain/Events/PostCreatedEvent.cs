using System;

namespace BlogApp.Domain.Events;

public record PostCreatedEvent(Guid PostId);
