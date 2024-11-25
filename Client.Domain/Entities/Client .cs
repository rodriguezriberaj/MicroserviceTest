using Domain.ValueObjects;
namespace Domain.Entities
{
    public class Client : Person
    {
        public ClientId ClientId { get; private set; }
        public Username Username { get; private set; }
        public Password Password { get; private set; }

        public Client(
            string name,
            Gender gender,
            int age,
            string identification,
            string address,
            string phoneNumber,
            Guid clientId,
            string username,
            string password
        ) : base(name, gender, age, identification, address, phoneNumber)
        {
            ClientId = new ClientId(clientId);
            Username = new Username(username);
            Password = new Password(password);
        }

        public void UpdateBasicInfo(string address, string phoneNumber){
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
        }

        private Client() { }
    }
}
