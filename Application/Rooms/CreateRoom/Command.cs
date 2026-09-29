using Domain.Enums;
using System;

namespace Application.Rooms.CreateRoom
{
    public sealed class Command
    {
        public Guid InstitutionId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string PhoneCountryCode { get; set; } = string.Empty;
        public required string PhoneNumber { get; set; } = string.Empty;
        public RoomType Type { get; set; }
    }
}
