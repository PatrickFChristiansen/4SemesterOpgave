using System;

namespace Application.Rooms.CreateRoom
{
    public sealed class CreateRoomCommand //nice name
    {
        public Guid InstitutionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneCountryCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Domain.Enums.RoomType Type { get; set; } = Domain.Enums.RoomType.nursury;
    }
}
