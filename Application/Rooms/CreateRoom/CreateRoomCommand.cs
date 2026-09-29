using System;
using Domain.Enums;
namespace Application.Rooms.CreateRoom
{
    public sealed class CreateRoomCommand
    {
        public Guid InstitutionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneCountryCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public RoomType Type { get; set; } 
    }
}
