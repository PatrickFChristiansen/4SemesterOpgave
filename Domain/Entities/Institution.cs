using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Institution : EntityBase
    {
        private readonly List<Room> _rooms = new();

        public string Name { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Room> Rooms
            => _rooms.AsReadOnly();

        protected Institution()
        {
            Name = string.Empty;
            Address = null!;
        }

        public Institution(
            string name,
            Address address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Institution name can't be empty.");

            Name = name.Trim();
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public void AddRoom(Room room)
        {
            if (room is null)
                throw new ArgumentNullException(nameof(room));

            if (_rooms.Any(x => x.Id == room.Id))
            {
                throw new InvalidOperationException(
                    "Room is already attached to this institution.");
            }

            _rooms.Add(room);
        }

        public void RemoveRoom(Guid roomId)
        {
            var room = _rooms.FirstOrDefault(x => x.Id == roomId);

            if (room is null)
            {
                throw new InvalidOperationException(
                    "Room not found.");
            }

            _rooms.Remove(room);
        }
    }
}