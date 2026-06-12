using Domain.ValueObjects;
using Domain.Enums;

namespace Domain.Entities
{
    public class Room : EntityBase
    {
        public Guid InstitutionId { get; private set; }
        public string Name { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public RoomType Type { get; private set; }

        protected Room()
        {
            Name = string.Empty;
            PhoneNumber = null!;
        }

        public Room(
            Guid institutionId,
            string name,
            PhoneNumber phoneNumber,
            RoomType type)
        {
            if (institutionId == Guid.Empty)
                throw new ArgumentException("Institution id can't be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Room name can't be empty.");

            InstitutionId = institutionId;
            Name = name.Trim();
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Type = type;
        }
    }
}