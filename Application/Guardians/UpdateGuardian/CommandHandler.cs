using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Guardians.UpdateGuardian
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
            var guardian = await _guardianRepository.GetByIdAsync(command.Id);

            if (guardian is null)
            {
                throw new InvalidOperationException(
                    $"Guardian with id '{command.Id}' was not found.");
            }

            var email = new Email(command.Email);
            var phoneNumber = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            var address = new Address(
                command.Street,
                command.City,
                command.StreetNumber,
                command.PostalCode);

            guardian.ChangeName(command.FirstName, command.LastName);
            guardian.UpdateContactDetails(email, phoneNumber, address);

            await _guardianRepository.UpdateAsync(guardian);
            return guardian.Id;
        }
    }
}
