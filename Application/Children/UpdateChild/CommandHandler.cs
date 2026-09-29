using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Children.UpdateChild
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
            var child = await _childRepository.GetByIdAsync(command.Id);

            if (child is null)
            {
                throw new InvalidOperationException(
                    $"Child with id '{command.Id}' was not found.");
            }

            var birthDate = new BirthDate(command.BirthDate);
            var cprLastFour = new CprLastFour(command.CprLastFour);

            var healthInformation = new HealthInformation(
                command.Allergies,
                command.Medication,
                command.Notes);

            child.ChangeName(
                command.FirstName,
                command.LastName);

            child.SetBirthDate(birthDate);
            child.SetCprLastFour(cprLastFour);
            child.AssignToRoom(command.RoomId);
            child.UpdateHealthInformation(healthInformation);

            await _childRepository.UpdateAsync(child);

            return child.Id;
        }
    }
}