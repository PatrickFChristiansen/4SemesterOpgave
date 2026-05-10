using System;

using Domain.ValueObjects;

namespace Domain.Entities
{
    public abstract class User : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }   
        public Address Address { get; private set; }

        protected User() { }
        protected   User(string firstName, string lastName, Email email, PhoneNumber phoneNumber, Address address)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name can't be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name can't be empty");
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
        public void ChangeName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name can't be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name can't be empty");
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            MarkAsUpdated();
        }
        public void ChangeEmail(Email email)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            MarkAsUpdated();
        }
        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            MarkAsUpdated();
        }
        public void ChangeAddress(Address address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            MarkAsUpdated();
        }
    }
}
