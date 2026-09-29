using System;
using Domain.Repositories;
using Domain.ValueObjects;



namespace Application.Children.CreateChild
{
    public sealed class CommandHandler
    {
        private readonly IChildRepository _childRepository;
        public CommandHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }
        public async Task<Guid> Handle(Command command)
        {

            var birthDate = new BirthDate(command.BirthDate);
            var cprLastFour = new CprLastFour(command.CprLastFour);
            var healthInformation = new HealthInformation(
                command.Allergies,
                command.Medication,
                command.Notes);

            var child = new Domain.Entities.Child(
                command.FirstName,
                command.LastName,
                birthDate,
                cprLastFour,
                command.RoomId,
                healthInformation);
            await _childRepository.AddAsync(child);
            return child.Id;
        }
    }
}
