using System;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;
using Domain.Enums;

namespace Application.Rooms.CreateRoom
{
    public sealed class CreateRoomCommandHandler
    {
        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Guid> Handle(CreateRoomCommand command)
        {
            var phone = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);

            var room = new Room(
                command.InstitutionId,
                command.Name,
                phone,
                command.Type);

            await _roomRepository.AddAsync(room);
            return room.Id;
        }
    }
}
