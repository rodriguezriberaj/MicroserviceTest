using Domain.Exceptions;

namespace Domain.ValueObjects
{
     public record Address
    {
        public string Value { get; }

        public Address(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidAddressException(value);

            if (value.Length > 200)
                throw new InvalidAddressException(value);

            Value = value;
        }

        private Address(){}
    }
}