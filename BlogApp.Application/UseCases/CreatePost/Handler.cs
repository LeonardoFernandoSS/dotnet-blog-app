using System;
using Balta.Mediator.Abstractions;
using BlogApp.Application.Interfaces;
using BlogApp.Application.Repositories;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Exceptions;
using BlogApp.Domain.ValueObjects;
using BlogApp.Domain.Events;
using BlogApp.Domain.Enums;
using BlogApp.Domain.Common;

namespace BlogApp.Application.UseCases.CreatePost;

public class Handler(ICurrentUser currentUser, IPostRepository postRepository, IUnitOfWork unitOfWork, IEventPublisher eventPublisher) : IHandler<Command, Response>
{
    public async Task<Response> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        if (!currentUser.IsAuthenticated)
            throw new UnauthorizedAccessException(Messages.User.NotAuthenticated);

        if (!currentUser.HasRole(RoleType.EDITOR) && !currentUser.HasPermission(PermissionType.CREATE_POST))
            throw new ForbiddenAccessException(Messages.Post.CannotCreatePost);

        var title = new Title(request.Title);
        var content = new Content(request.Content);

        if (await postRepository.IsUniqueTitleAsync(title) == false)
        {
            throw new DuplicateEntityException(Messages.Post.PostTitleAlreadyExists);
        }

        var post = PostDraft.Factories.Create(title, content);

        await postRepository.CreateAsync(post);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await eventPublisher.PublishAsync(new PostCreatedEvent(post.Id));

        return new Response(post.Id.ToString());
    }
}

