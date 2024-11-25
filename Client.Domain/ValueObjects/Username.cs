using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record Username
    {
        public string Value { get; }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidUsernameException(value);

            if (value.Length < 3 || value.Length > 50)
                throw new InvalidUsernameException(value);

            Value = value;
        }

         private Username(){}
    
    }
}