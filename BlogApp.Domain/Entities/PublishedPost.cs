using BlogApp.Domain.Common;
using BlogApp.Domain.Enums;

namespace BlogApp.Domain.Entities;

public class PublishedPost : Post
{
    public DateTime PublishedAt { get; private set; }

    public void ToggleStatus()
    {
        if (Status == PostStatus.DELETED)
        {
            throw new Exception(Messages.Post.PostIsDeletedAndCannotBeToggled);
        }

        Status = Status == PostStatus.ACTIVE ? PostStatus.INATIVE : PostStatus.ACTIVE;
    }

    public static class Factories
    {
        public static PublishedPost Create(PostDraft postDraft)
        {
            return new PublishedPost()
            {
                Id = postDraft.Id,
                Title = postDraft.Title,
                Content = postDraft.Content,
                CreatedAt = postDraft.CreatedAt,
                UpdatedAt = postDraft.UpdatedAt,
                PublishedAt = DateTime.UtcNow,
                Type = PostType.PUBLISHED,
                Status = PostStatus.ACTIVE,
            };
        }
    }
}
