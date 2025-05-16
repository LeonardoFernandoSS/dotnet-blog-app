using System;
using BlogApp.Domain.Common;

namespace BlogApp.Domain.ValueObjects;

public class Content
{
    private readonly int _maxLength = 255;

    public string Value { get; }

    public Content(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            var message = Messages.Validation.CannotBeEmpty(nameof(Content));

            throw new ArgumentException(message, nameof(value));
        }

        if (value.Length > _maxLength)
        {
            var message = Messages.Validation.CannotExceedMaxLength(nameof(Content), _maxLength);

            throw new ArgumentException(message, nameof(value));
        }

        Value = value;
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj) => obj is Content content && Value == content.Value;

    public override int GetHashCode() => Value.GetHashCode();
}
