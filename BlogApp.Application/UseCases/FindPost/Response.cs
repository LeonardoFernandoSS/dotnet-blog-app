using System;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.UseCases.FindPost;

public class Response
{
    public string Message { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }

    public Response(Post post)
    {
        Message = "Post founded successfully";
        Title = post.Title.ToString();
        Content = post.Content.ToString();
        Status = post.Status.ToString();
    }
}
