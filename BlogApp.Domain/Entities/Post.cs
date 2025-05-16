using BlogApp.Domain.Common;
using BlogApp.Domain.Enums;
using BlogApp.Domain.ValueObjects;

namespace BlogApp.Domain.Entities;

public abstract class Post
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public Title Title { get; protected set; } = new Title(string.Empty);
    public Content Content { get; protected set; } = new Content(string.Empty);
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public PostType Type { get; protected set; }
    public PostStatus Status { get; protected set; }

    protected Post() { }

    public void Delete()
    {
        if (Status == PostStatus.DELETED)
        {
            throw new Exception(Messages.Post.PostIsAlreadyDeleted);
        }

        Status = PostStatus.DELETED;
    }

    public void Update(Title title, Content content)
    {
        if (Status == PostStatus.DELETED)
        {
            throw new Exception(Messages.Post.PostIsDeletedAndCannotBeUpdated);
        }

        Title = title;
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}
