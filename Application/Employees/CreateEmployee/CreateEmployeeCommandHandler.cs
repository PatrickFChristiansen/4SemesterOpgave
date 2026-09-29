using System;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;

namespace Application.Employees.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand command)
        {
            var email = new Email(command.Email);
            var phone = new PhoneNumber(command.PhoneCountryCode, command.PhoneNumber);
            var address = new Address(command.Street, command.City, command.StreetNumber, command.PostalCode);

            var employee = new Employee(
                command.InstitutionId,
                command.FirstName,
                command.LastName,
                email,
                phone,
                address,
                command.Level);

            await _employeeRepository.AddAsync(employee);
            return employee.Id;
        }
    }
}
