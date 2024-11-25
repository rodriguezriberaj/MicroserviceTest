using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record Age
    {
        public int Value { get; }

        public Age(int value)
        {
            if (value is <= 0 or > 120)
                throw new InvalidAgeException(value);

            Value = value;
        }
        private Age(){}
    }
}