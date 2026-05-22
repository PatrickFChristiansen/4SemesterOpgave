using Domain.ValueObjects;
using System;   


namespace Domain.Entities
{
    public class Institution : EntityBase
    {
        public string Name { get; private set; }

        public Address Address { get; private set; }

        private readonly List<Room> _rooms = [];
        public IReadOnlyCollection<Room> Rooms => _rooms.AsReadOnly();

        protected Institution() { }

        public Institution(
            string name,
            Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
