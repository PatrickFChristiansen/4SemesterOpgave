using System;

namespace Application.Children.CreateChild
{
    public sealed class CreateChildCommand
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string CprLastFour { get; set; } = string.Empty;
        public Guid RoomId { get; set; }
        public string? Allergies { get; set; }
        public string? Medication { get; set; }
        public string? Notes { get; set; }
    }
}
