using System;

namespace Application.Employees.CreateEmployee
{
    public sealed class CreateEmployeeCommand
    {
        public Guid InstitutionId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneCountryCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public Domain.Enums.EmployeeLevel Level { get; set; } = Domain.Enums.EmployeeLevel.Employee;
    }
}
