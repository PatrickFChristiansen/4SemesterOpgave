using System;


namespace Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        private Email() {
            Value = null!;
                }
  
    public Email(string value)
        {
            if(string .IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email can't be empty");
            value = value.Trim().ToLowerInvariant();
            if (!IsValid(value))
                throw new ArgumentException("Invalid email format");
            Value = value;

        }
        private static bool IsValid(string email)
        {
            var parts = email.Split('@');
            if (parts.Length != 2)
                return false;
            var localpart = parts[0];
            var domainPart = parts[1];
            if (string.IsNullOrWhiteSpace(localpart) || string .IsNullOrWhiteSpace(domainPart))
                return false;

            if (!domainPart.Contains('.'))
                return false;
           
            return true;

        }

        public override string ToString()
        {
            return Value;
        }



    }

}
