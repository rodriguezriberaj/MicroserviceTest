namespace Application.DTOs
{
    public record ClientDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid ClientId { get; set; }
    }
}