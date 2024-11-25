namespace Domain.ValueObjects
{
     public enum Gender
    {
        Male,
        Female,
    }

    public record GenderValue
    { 
        public Gender Value { get; }

        public GenderValue(string gender)
        {
            if (!Enum.TryParse(typeof(Gender), gender, true, out var result) || result is not Gender)
                throw new ArgumentException($"Invalid gender: {gender}");

            Value = (Gender)result!;
        }

        public GenderValue(Gender gender)
        {
            Value = gender;
        }

        private GenderValue() { }
    }
}