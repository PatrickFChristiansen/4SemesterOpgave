using System;
using Domain.ValueObjects;
using Domain.Repositories;
using System.Security.Cryptography.X509Certificates;


namespace Application.Children.CreateChild
{
    public class Command
    {
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required DateOnly BirthDate { get; set; }
        public required string CprLastFour { get; set; } = string.Empty;
        public required Guid RoomId { get; set; }

        public string? Allergies { get; set; }
        public string? Medication { get; set; }
        public string? Notes { get; set; }



    }
}