using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record Password
    {
        public string Value { get; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidPasswordException(value);

            if (value.Length < 8)
                throw new InvalidPasswordException(value);

            Value = value;
        }

        private Password(){}
    }
}