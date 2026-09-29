using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Employees.UpdateEmployee
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
            var employee = await _employeeRepository.GetByIdAsync(command.Id);

            if (employee is null)
            {
                throw new InvalidOperationException(
                    $"Employee with id '{command.Id}' was not found.");
            }

            var email = new Email(command.Email);
            var phoneNumber = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            var address = new Address(
                command.Street,
                command.City,
                command.StreetNumber,
                command.PostalCode);

            employee.ChangeName(command.FirstName, command.LastName);
            employee.UpdateContactDetails(email, phoneNumber, address);
            employee.UpdateEmploymentDetails(command.InstitutionId, command.Level);

            await _employeeRepository.UpdateAsync(employee);
            return employee.Id;
        }
    }
}
