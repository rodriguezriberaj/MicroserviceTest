using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UpdateClientDto : IValidatableObject
    {
        public Guid ClientId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClientId == Guid.Empty)
            {
                yield return new ValidationResult("ClientId is required.");
            }

            if (!Guid.TryParse(ClientId.ToString(), out _))
            {
                yield return new ValidationResult("Invalid ClientId format.");
            }

            if(string.IsNullOrEmpty(Address)){
                yield return new ValidationResult("Address is required.");
            }

            if(string.IsNullOrEmpty(PhoneNumber)){
                yield return new ValidationResult("PhoneNumber is required.");
            }
        }
    }
}