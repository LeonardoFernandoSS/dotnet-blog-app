using System;

namespace BlogApp.Application.UseCases.CreatePost;

public class Response
{
    public string Message { get; set; }
    public string PostId { get; set; }

    public Response(string postId)
    {
        Message = "Post created successfully";
        PostId = postId;
    }
}
