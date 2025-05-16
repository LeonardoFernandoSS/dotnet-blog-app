using System;
using BlogApp.Domain.Entities;
using BlogApp.Domain.ValueObjects;

namespace BlogApp.Application.Repositories;

public interface IPostRepository
{
    Task<bool> IsUniqueTitleAsync(Title title, Guid? idIgnored = null);
    Task CreateAsync(Post post);
    Task<Post?> GetByIdAsync(Guid id);
}
