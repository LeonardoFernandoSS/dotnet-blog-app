using System;
using BlogApp.Domain.Enums;

namespace BlogApp.Application.Interfaces;

public interface ICurrentUser
{
    Guid? UserId { get; }
    string? Email { get; }
    bool IsAuthenticated { get; }
    bool HasRole(RoleType role);
    bool HasPermission(PermissionType permission);
}
