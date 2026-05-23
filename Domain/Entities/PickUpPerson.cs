using System;
using Domain.ValueObjects;



namespace Domain.Entities
{
    public class PickupPerson : EntityBase
    {
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string RelationToChild { get; private set; }

        public Guid ChildId { get; private set; }

        public void Update(
            string fullName,
            string phoneNumber,
            string relationToChild)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            RelationToChild = relationToChild;
        }
    }
}
