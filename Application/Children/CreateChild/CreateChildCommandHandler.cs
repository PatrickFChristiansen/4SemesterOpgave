using System;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;

namespace Application.Children.CreateChild
{
    public sealed class CreateChildCommandHandler
    {
        private readonly IChildRepository _childRepository;

        public CreateChildCommandHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<Guid> Handle(CreateChildCommand command)
        {
            var birthDate = new BirthDate(command.BirthDate);
            var cpr = new CprLastFour(command.CprLastFour);
            var health = new HealthInformation(command.Allergies, command.Medication, command.Notes);

            var child = new Child(
                command.FirstName,
                command.LastName,
                birthDate,
                cpr,
                command.RoomId,
                health);

            await _childRepository.AddAsync(child);
            return child.Id;
        }
    }
}
