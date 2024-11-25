using System;

namespace Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message) { }
    }

    public class InvalidNameException : DomainException
    {
        public InvalidNameException(string name)
            : base($"The name '{name}' is invalid. It must be non-empty and less than 100 characters.") { }
    }

    public class InvalidAgeException : DomainException
    {
        public InvalidAgeException(int age)
            : base($"The age '{age}' is invalid. It must be between 0 and 120.") { }
    }

    public class InvalidPhoneNumberException : DomainException
    {
        public InvalidPhoneNumberException(string phoneNumber)
            : base($"The phone number '{phoneNumber}' is invalid. It must be between 7 and 15 digits.") { }
    }

    public class InvalidIdentificationException : DomainException
    {
        public InvalidIdentificationException(string value)
            : base($"The identification '{value}' is invalid. It must be alphanumeric and between 10-12 characters.") { }
    }

     public class InvalidAddressException : DomainException
    {
        public InvalidAddressException(string value)
            : base($"The address '{value}' is invalid. It must not be empty and must be 200 characters or fewer.") { }
    }

    public class InvalidClientIdException : DomainException
    {
        public InvalidClientIdException(Guid value)
            : base($"The ClientId '{value}' is invalid. It cannot be empty.") { }
    }

    public class InvalidUsernameException : DomainException
    {
        public InvalidUsernameException(string value)
            : base($"The Username '{value}' is invalid. It must be between 3 and 50 characters.") { }
    }

    public class InvalidPasswordException : DomainException
    {
        public InvalidPasswordException(string value)
            : base("The Password is invalid. It must be at least 8 characters long.") { }
    }
}