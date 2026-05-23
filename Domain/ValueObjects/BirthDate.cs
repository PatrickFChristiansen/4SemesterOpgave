using System;




namespace Domain.ValueObjects
{
    public class BirthDate
    {
        public DateOnly Value { get; private set; }

        protected BirthDate() { }

        public BirthDate(DateOnly value)
        {
            if (value > DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentException("Birth date can't be in the future.");

            Value = value;
        }
    }
}
