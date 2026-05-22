using Domain.ValueObjects;
using System;
using Domain.Enums;


namespace Domain.Entities
{
    public class Room : EntityBase
    {
        public Guid InstitutionId { get; private set; }
        public string Name { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public RoomType Type { get; private set; }
        public Room(
            Guid institutionId,
            string name,
            PhoneNumber phoneNumber,
            RoomType type)
        {
            InstitutionId = institutionId;
            Name = name;
            PhoneNumber = phoneNumber;
            Type = type;
        }



        protected Room()
        {
            Name = string.Empty;
            PhoneNumber = null!;
        }



    }
}
