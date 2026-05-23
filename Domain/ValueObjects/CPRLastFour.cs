using System;



namespace Domain.ValueObjects
{
    public class CprLastFour
    {
        public string Value { get; private set; }

        protected CprLastFour() { }

        public CprLastFour(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPR last four can't be empty.");

            value = value.Trim();

            if (value.Length != 4)
                throw new ArgumentException("CPR last four must be exactly 4 digits.");

            if (!value.All(char.IsDigit))
                throw new ArgumentException("CPR last four must only contain digits.");

            Value = value;
        }
    }
}

