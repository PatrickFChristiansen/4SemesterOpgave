using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Employees.CreateEmployee
{
    public sealed class CommandHandler
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> Handle(Command command)
        {
            var email = new Email(command.Email);
            var phoneNumber = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            var address = new Address(
                command.Street,
                command.City,
                command.StreetNumber,
                command.PostalCode);

            var employee = new Employee(
                command.InstitutionId,
                command.FirstName,
                command.LastName,
                email,
                phoneNumber,
                address,
                command.Level);

            await _employeeRepository.AddAsync(employee);
            return employee.Id;
        }
    }
}
