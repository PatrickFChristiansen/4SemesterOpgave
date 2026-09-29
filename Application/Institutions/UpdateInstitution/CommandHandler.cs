using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Institutions.UpdateInstitution
{
    public sealed class CommandHandler
    {
        private readonly IInstitutionRepository _institutionRepository;

        public CommandHandler(IInstitutionRepository institutionRepository)
        {
            _institutionRepository = institutionRepository;
        }

        public async Task<Guid> Handle(Command command)
        {
            var institution =
                await _institutionRepository.GetByIdAsync(command.Id);

            if (institution is null)
            {
                throw new InvalidOperationException(
                    $"Institution with id '{command.Id}' was not found.");
            }

            var address = new Address(
                command.Street,
                command.City,
                command.StreetNumber,
                command.PostalCode);

            institution.Update(
                command.Name,
                address);

            await _institutionRepository.UpdateAsync(institution);

            return institution.Id;
        }
    }
}