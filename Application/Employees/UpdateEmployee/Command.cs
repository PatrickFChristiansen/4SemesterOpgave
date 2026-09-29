using Domain.Enums;
using System;

namespace Application.Employees.UpdateEmployee
{
    public sealed class Command
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string PhoneCountryCode { get; set; } = string.Empty;
        public required string PhoneNumber { get; set; } = string.Empty;
        public required string Street { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required string StreetNumber { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;
        public EmployeeLevel Level { get; set; }
    }
}
