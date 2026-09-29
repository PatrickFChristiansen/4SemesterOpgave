using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Rooms.CreateRoom
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
            var phoneNumber = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            var room = new Room(
                command.InstitutionId,
                command.Name,
                phoneNumber,
                command.Type);

            await _roomRepository.AddAsync(room);
            return room.Id;
        }
    }
}
