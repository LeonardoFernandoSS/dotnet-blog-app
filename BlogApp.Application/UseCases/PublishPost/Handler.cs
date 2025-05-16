using System;
using Balta.Mediator.Abstractions;
using BlogApp.Application.Interfaces;
using BlogApp.Application.Repositories;
using BlogApp.Domain.Common;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Enums;
using BlogApp.Domain.Events;
using BlogApp.Domain.Exceptions;

namespace BlogApp.Application.UseCases.PublishPost;

public class Handler(ICurrentUser currentUser, IPostDraftRepository postRepository, IUnitOfWork unitOfWork, IEventPublisher eventPublisher) : IHandler<Command, Response>
{
    public async Task<Response> HandleAsync(Command request, CancellationToken cancellationToken)
    {
        if (!currentUser.IsAuthenticated)
            throw new UnauthorizedAccessException(Messages.User.NotAuthenticated);

        if (!currentUser.HasRole(RoleType.EDITOR) && !currentUser.HasPermission(PermissionType.PUBLISH_POST))
            throw new ForbiddenAccessException(Messages.Post.CannotPublishPost);

        if (!Guid.TryParse(request.PostId, out var postId))
            throw new DomainException(Messages.Post.InvalidPostIDFormat);

        var draft = await postRepository.GetByIdAsync(postId, cancellationToken);

        if (draft is null)
            throw new NotFoundException(nameof(PostDraft), postId);

        var publishedPost = draft.Publish();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await eventPublisher.PublishAsync(new PostPublishedEvent(publishedPost.Id));

        return new Response(publishedPost.Id.ToString());
    }
}
