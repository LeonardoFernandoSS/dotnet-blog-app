using System;
using Balta.Mediator.Abstractions;

namespace BlogApp.Application.UseCases.PublishPost;

public record Command(string PostId) : IRequest<Response>;
