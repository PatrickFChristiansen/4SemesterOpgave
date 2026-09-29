using System;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;


namespace Application.Institutions.CreateInstitution
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
            var address = new Address(
                command.Street,
                command.City,
                command.StreetNumber,
                command.PostalCode);
            var institution = new Institution(
                command.Name,
                address);
            await _institutionRepository.AddAsync(institution);
            return institution.Id;
        }



    }

}
