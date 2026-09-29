using System;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;

namespace Application.Guardians.CreateGuardian
{
    public sealed class CreateGuardianCommandHandler
    {
        private readonly IGuardianRepository _guardianRepository;

        public CreateGuardianCommandHandler(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }

        public async Task<Guid> Handle(CreateGuardianCommand command)
        {
            var email = new Email(command.Email);
            var phone = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            var address = new Address(command.Street, command.City, command.StreetNumber, command.PostalCode);

            var guardian = new Guardian(
                command.FirstName,
                command.LastName,
                email,
                address,
                phone);

            await _guardianRepository.AddAsync(guardian);
            return guardian.Id;
        }
    }
}
