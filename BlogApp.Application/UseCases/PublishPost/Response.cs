using System;

namespace BlogApp.Application.UseCases.PublishPost;

public class Response
{
    public string Message { get; set; }
    public string PostId { get; set; }

    public Response(string postId)
    {
        Message = "Post published successfully";
        PostId = postId;
    }
}
