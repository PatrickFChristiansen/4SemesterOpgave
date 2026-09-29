using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Rooms.UpdateRoom
{
    public sealed class CommandHandler
    {
        private readonly IRoomRepository _roomRepository;

        public CommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Guid> Handle(Command command)
        {
            var room = await _roomRepository.GetByIdAsync(command.Id);

            if (room is null)
            {
                throw new InvalidOperationException(
                    $"Room with id '{command.Id}' was not found.");
            }

            var phoneNumber = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            room.Update(
                command.InstitutionId,
                command.Name,
                phoneNumber,
                command.Type);

            await _roomRepository.UpdateAsync(room);
            return room.Id;
        }
    }
}
