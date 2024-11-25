using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidPhoneNumber(value))
                throw new InvalidPhoneNumberException(value);

            Value = value;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length is >= 7 and <= 15 && long.TryParse(phoneNumber, out _);
        }

        private PhoneNumber(){}
    }
}