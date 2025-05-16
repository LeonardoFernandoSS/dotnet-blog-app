using System;

namespace BlogApp.Domain.Common;

public static class Messages
{

    public static class User
    {
        public const string NotAuthenticated = "User is not authenticated.";
    }

    public static class Post
    {
        public const string PostIsAlreadyDeleted = "Post is already deleted.";
        public const string PostIsDeletedAndCannotBeUpdated = "Post is deleted and cannot be updated.";
        public const string PostIsDeletedAndCannotBeToggled = "Post is deleted and cannot be toggled.";
        public const string InvalidPostIDFormat = "Invalid post ID format.";
        public const string PostTitleAlreadyExists = "A post with this title already exists.";
        public const string CannotCreatePost = "Cannot create post. User does not have the required permissions.";
        public const string CannotPublishPost = "Cannot publish post. User does not have the required permissions.";
    }

    public static class Validation
    {
        public static string CannotBeEmpty(string fieldName)
            => $"{fieldName} cannot be empty.";
        public static string CannotExceedMaxLength(string fieldName, int maxLength)
            => $"{fieldName} cannot exceed {maxLength} characters.";
    }

    public static class Exception
    {
        public static string NotFound(string entityName, object id)
            => $"Entity {entityName} with id {id} not found.";
    }
}
