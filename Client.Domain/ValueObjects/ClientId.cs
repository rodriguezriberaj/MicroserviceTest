using Domain.Entities;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class ClientId
    {
        public Guid Value { get; }

        public ClientId(Guid value)
        {
            if (value == Guid.Empty)
                throw new InvalidClientIdException(value);

            Value = value;
        }
        private ClientId(){}

        public override bool Equals(object obj)
        {
            if (obj is ClientId other)
            {
                return Value.Equals(other.Value);
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
        
    }
}