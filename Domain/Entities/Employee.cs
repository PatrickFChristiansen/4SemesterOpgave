using System;
using Domain.ValueObjects;
using Domain.Enums;


namespace Domain.Entities
{
    public class Employee : User
    {
        public EmployeeLevel Level { get; private set; }

        public Guid InstitutionID { get; private set; }

        public Employee(
            Guid institutionID,
            string firstName,
            string lastName,    
            Email email,
            PhoneNumber phoneNumber,
            Address address,
            EmployeeLevel level) : base(firstName, lastName, email, phoneNumber, address)
        {
            InstitutionID = institutionID;
            Level = level;
        }



        public Employee() { }
    }
}
