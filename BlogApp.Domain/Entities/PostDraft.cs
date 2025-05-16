using BlogApp.Domain.Enums;
using BlogApp.Domain.ValueObjects;

namespace BlogApp.Domain.Entities;

public class PostDraft : Post
{
    public PublishedPost Publish()
    {
        return PublishedPost.Factories.Create(this);
    }

    public static class Factories
    {
        public static PostDraft Create(Title title, Content content)
        {
            return new PostDraft()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                Type = PostType.DRAFTED,
                Status = PostStatus.ACTIVE,
            };
        }
    }
}
