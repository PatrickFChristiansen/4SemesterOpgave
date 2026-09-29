using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Guardians.CreateGuardian
{
    public sealed class CommandHandler
    {
        private readonly IGuardianRepository _guardianRepository;

        public CommandHandler(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }

        public async Task<Guid> Handle(Command command)
        {
            var email = new Email(command.Email);
            var address = new Address(
                command.Street,
                command.City,
                command.StreetNumber,
                command.PostalCode);
            var phoneNumber = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);

            var guardian = new Guardian(
                command.FirstName,
                command.LastName,
                email,
                address,
                phoneNumber);

            await _guardianRepository.AddAsync(guardian);
            return guardian.Id;
        }
    }
}
