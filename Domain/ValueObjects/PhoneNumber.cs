using System;
using System.Linq;

namespace Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string CountryCode { get; private set; }
        public string Number { get; private set; }


        private PhoneNumber() { }


        public PhoneNumber(string countryCode, string number)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentException("Country code can't be empty");
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number can't be empty");
            countryCode = countryCode.Trim();
            number = number
                .Replace(" ", "")
                .Replace("-", "");


            if (!countryCode.StartsWith("+"))
                countryCode = "+" + countryCode;

            if (!countryCode.Skip(1).All(char.IsDigit))
                throw new ArgumentException("Invalid Country code");

            if (!number.All(char.IsDigit))
                throw new ArgumentException("Invalid phone number");

            if (number.Length < 6 || number.Length > 15)
                throw new ArgumentException("Phone number must be between 6 and 15 digits");

            if (countryCode == "+45" && number.Length != 8)
                throw new ArgumentException("Danish phone numbers must be exactly 8 digits");

            CountryCode = countryCode;
            Number = number;

        }
    }
}
