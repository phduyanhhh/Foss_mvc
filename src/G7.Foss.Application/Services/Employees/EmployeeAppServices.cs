using System.Threading.Tasks;
using Abp.Domain.Repositories;
using G7.Foss.Entities;
using G7.Foss.Services.Employees.Dtos;

namespace G7.Foss.Services.Employees;

public class EmployeeAppServices : FossAppServiceBase, IEmployeeAppServices
{
    private readonly IRepository<Employee, int> _repositoryEmployeeAppService;

    public EmployeeAppServices(IRepository<Employee, int> repositoryEmployeeAppService)
    {
        _repositoryEmployeeAppService = repositoryEmployeeAppService;
    }

    public async Task Create(CreateEmployeeInput input)
    {
        Employee newEmployee = new()
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            PhoneNumber = input.PhoneNumber,
            Address = input.Address,
            Salary = input.Salary,
            Position = input.Position,
            DateOfBirth = input.DateOfBirth,
            Gender = input.Gender
        };
        
        await _repositoryEmployeeAppService.InsertAsync(newEmployee);
    }
}