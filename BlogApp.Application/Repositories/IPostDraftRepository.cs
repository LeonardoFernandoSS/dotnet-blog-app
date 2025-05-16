using System;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Repositories;

public interface IPostDraftRepository
{
    Task<PostDraft?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
