using System;
using Balta.Mediator.Abstractions;

namespace BlogApp.Application.UseCases.FindPost;

public record Query(string PostId) : IRequest<Response>;
