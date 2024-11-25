using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record Identification
    {
        public string Value { get; }

        public Identification(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidIdentificationException(value);

            if (!IsValidFormat(value))
                throw new InvalidIdentificationException(value);

            Value = value;
        }

        private bool IsValidFormat(string value)
        {
            return value.Length is >= 6 and <= 12 && value.All(char.IsLetterOrDigit);
        }

        private Identification() { }
    }
}