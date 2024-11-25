using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
                throw new InvalidNameException(value);

            Value = value;
        }

        private Name(){}
    }
}
