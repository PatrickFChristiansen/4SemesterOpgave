using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class PickupPerson : EntityBase
    {
        public string FullName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string RelationToChild { get; private set; }
        public Guid ChildId { get; private set; }

        protected PickupPerson() { }

        public PickupPerson(
            Guid childId,
            string fullName,
            PhoneNumber phoneNumber,
            string relationToChild)
        {
            if (childId == Guid.Empty)
                throw new ArgumentException("Child id can't be empty.");

            ChildId = childId;
            Update(fullName, phoneNumber, relationToChild);
        }

        public void Update(
            string fullName,
            PhoneNumber phoneNumber,
            string relationToChild)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name can't be empty.");

            if (string.IsNullOrWhiteSpace(relationToChild))
                throw new ArgumentException("Relation to child can't be empty.");

            FullName = fullName.Trim();
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            RelationToChild = relationToChild.Trim();
        }
    }
}