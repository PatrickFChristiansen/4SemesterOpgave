using Domain.ValueObjects;
using System;
namespace Domain.Entities
{
    public class Child : EntityBase
    {
        private readonly List<ChildGuardian> _guardians = new();
        private readonly List<PickupPerson> _pickupPersons = new();
        private readonly List<SpecialNeed> _specialNeeds = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public CprLastFour CprLastFour { get; private set; }
        public Guid RoomId { get; private set; }
        public HealthInformation HealthInformation { get; private set; }

        public IReadOnlyCollection<ChildGuardian> Guardians => _guardians.AsReadOnly();
        public IReadOnlyCollection<PickupPerson> PickupPersons => _pickupPersons.AsReadOnly();
        public IReadOnlyCollection<SpecialNeed> SpecialNeeds => _specialNeeds.AsReadOnly();

        protected Child() { }

        public Child(
            string firstName,
            string lastName,
            BirthDate birthDate,
            CprLastFour cprLastFour,
            Guid roomId,
            HealthInformation healthInformation)
        {
            ChangeName(firstName, lastName);
            SetBirthDate(birthDate);
            SetCprLastFour(cprLastFour);
            AssignToRoom(roomId);
            UpdateHealthInformation(healthInformation);
        }

        public void ChangeName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name can't be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name can't be empty.");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        public void SetBirthDate(BirthDate birthDate)
        {
            BirthDate = birthDate
                ?? throw new ArgumentNullException(nameof(birthDate));
        }

        public void SetCprLastFour(CprLastFour cprLastFour)
        {
            CprLastFour = cprLastFour
                ?? throw new ArgumentNullException(nameof(cprLastFour));
        }

        public void AssignToRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
                throw new ArgumentException("Room id can't be empty.");

            RoomId = roomId;
        }

        public void UpdateHealthInformation(HealthInformation healthInformation)
        {
            HealthInformation = healthInformation
                ?? throw new ArgumentNullException(nameof(healthInformation));
        }

        public void AddGuardian(ChildGuardian guardian)
        {
            if (guardian is null)
                throw new ArgumentNullException(nameof(guardian));

            if (_guardians.Any(x => x.GuardianId == guardian.GuardianId))
                throw new InvalidOperationException("Guardian is already connected to this child.");

            _guardians.Add(guardian);
        }

        public void RemoveGuardian(Guid guardianId)
        {
            var guardian = _guardians.FirstOrDefault(x => x.GuardianId == guardianId);

            if (guardian is null)
                throw new InvalidOperationException("Guardian relation not found.");

            _guardians.Remove(guardian);
        }

        public void AddPickupPerson(PickupPerson pickupPerson)
        {
            if (pickupPerson is null)
                throw new ArgumentNullException(nameof(pickupPerson));

            if (_pickupPersons.Any(x =>
                    x.FullName == pickupPerson.FullName &&
                    x.PhoneNumber == pickupPerson.PhoneNumber))
            {
                throw new InvalidOperationException("Pickup person already exists for this child.");
            }

            _pickupPersons.Add(pickupPerson);
        }

        public void RemovePickupPerson(Guid pickupPersonId)
        {
            var pickupPerson = _pickupPersons.FirstOrDefault(x => x.Id == pickupPersonId);

            if (pickupPerson is null)
                throw new InvalidOperationException("Pickup person not found.");

            _pickupPersons.Remove(pickupPerson);
        }

        public void AddSpecialNeed(SpecialNeed specialNeed)
        {
            if (specialNeed is null)
                throw new ArgumentNullException(nameof(specialNeed));

            _specialNeeds.Add(specialNeed);
        }

        public void RemoveSpecialNeed(Guid specialNeedId)
        {
            var specialNeed = _specialNeeds.FirstOrDefault(x => x.Id == specialNeedId);

            if (specialNeed is null)
                throw new InvalidOperationException("Special need not found.");

            _specialNeeds.Remove(specialNeed);
        }
    }
}


