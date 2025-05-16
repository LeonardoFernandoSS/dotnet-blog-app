using System;
using Balta.Mediator.Abstractions;

namespace BlogApp.Application.UseCases.CreatePost;

public record Command(string Title, string Content) : IRequest<Response>;
