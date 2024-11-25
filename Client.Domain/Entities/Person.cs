using Domain.ValueObjects;
namespace Domain.Entities
{
    public class Person
    {
        public Name Name { get; private set; }
        public GenderValue Gender { get; private set; }
        public Age Age { get; private set; }
        public Identification Identification { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public Person(
            string name, 
            Gender gender, 
            int age, 
            string identification, 
            string address, 
            string phoneNumber)
        {
            Name = new Name(name);
            Gender = new GenderValue(gender);
            Age = new Age(age);
            Identification = new Identification(identification);
            Address = new Address(address);
            PhoneNumber = new PhoneNumber(phoneNumber);
        }

        public void SetAddress (string newAddress){
            Address = new Address(newAddress);
        }

        public void SetPhoneNumber (string newPhoneNumber){
            PhoneNumber = new PhoneNumber(newPhoneNumber);
        }

        public Person(){ }
    }
}