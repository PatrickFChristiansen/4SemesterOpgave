using System;

namespace Application.Institutions.UpdateInstitution
{
    public sealed class Command
    {
        public Guid Id { get; set; }

        public required string Name { get; set; } = string.Empty;
        public required string Street { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required string StreetNumber { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;
    }
}