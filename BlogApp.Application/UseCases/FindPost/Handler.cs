using System;
using Balta.Mediator.Abstractions;
using BlogApp.Application.Repositories;
using BlogApp.Domain.Common;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Exceptions;

namespace BlogApp.Application.UseCases.FindPost;

public class Handler(IPostRepository postRepository) : IHandler<Query, Response>
{
    public async Task<Response> HandleAsync(Query request, CancellationToken cancellationToken = default)
    {
        if (!Guid.TryParse(request.PostId, out var postId))
            throw new DomainException(Messages.Post.InvalidPostIDFormat);

        var post = await postRepository.GetByIdAsync(postId);

        if (post is null)
        {
            throw new NotFoundException(nameof(Post), postId);
        }

        return new Response(post);
    }
}
