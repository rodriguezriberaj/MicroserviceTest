using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record CreateClientDto : IValidatableObject
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required.", new[] { nameof(Name) });
            }
          
            if (string.IsNullOrEmpty(Gender))
            {
                yield return new ValidationResult("Gender is required.", new[] { nameof(Gender) });
            }

            if (string.IsNullOrEmpty(Identification))
            {
                yield return new ValidationResult("Identification is required.", new[] { nameof(Identification) });
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("Phone number is required.", new[] { nameof(PhoneNumber) });
            }

            if (ClientId == Guid.Empty)
            {
                yield return new ValidationResult("ClientId cannot be empty.", new[] { nameof(ClientId) });
            }

            if (string.IsNullOrEmpty(Username))
            {
                yield return new ValidationResult("Username is required.", new[] { nameof(Username) });
            }

            if (string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password is required.", new[] { nameof(Password) });
            }
            else if (Password.Length < 8)
            {
                yield return new ValidationResult("Password must be at least 6 characters long.", new[] { nameof(Password) });
            }
        }
    }

    
}