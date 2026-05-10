using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string StreetNumber { get; private set; }
        public string PostalCode { get; private set; }


        private Address()
        {
        }

        public Address(string street, string city, string streetNumber, string postalCode)
        {


            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("City can't be empty");

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code can't be empty");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City can't be empty");

            if (string.IsNullOrWhiteSpace(streetNumber))
                throw new ArgumentException("Streetname can't be empty");

            Street = street.Trim();
            City = city.Trim();
            StreetNumber = streetNumber.Trim();
            PostalCode = postalCode.Trim();
        }


    }
}

