using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using G7.Foss.Entities;
using G7.Foss.Services.Employees.Dtos;
using Microsoft.EntityFrameworkCore;

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

    public async Task<PagedResultDto<EmployeeListDto>> GetList(GetAllEmployeeInput input)
    {
        IQueryable<Employee> query = _repositoryEmployeeAppService
            .GetAll()
            .WhereIf(!input.Search.IsNullOrWhiteSpace(),
                x => x.FirstName.ToLower().Contains(input.Search.ToLower()));

        int totalCount = await query.CountAsync();

        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = "CreationTime DESC";
        }

        List<EmployeeListDto> items = await query.PageBy(input).OrderBy(input.Sorting)
            .Select(x => new EmployeeListDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                Salary = x.Salary,
                Position = x.Position,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender
            }).ToListAsync();

        return new PagedResultDto<EmployeeListDto>(totalCount, items);
    }

    public async Task<EmployeeListDto> GetEmployeeById(int id)
    {
        Employee existingEmployeeById = await _repositoryEmployeeAppService.FirstOrDefaultAsync(x => x.Id == id);
        if (existingEmployeeById == null)
        {
            throw new UserFriendlyException("Employee not found");
        }

        EmployeeListDto employeeDto = new()
        {
            Id = existingEmployeeById.Id,
            FirstName = existingEmployeeById.FirstName,
            LastName = existingEmployeeById.LastName,
            Email = existingEmployeeById.Email,
            PhoneNumber = existingEmployeeById.PhoneNumber,
            Address = existingEmployeeById.Address,
            Salary = existingEmployeeById.Salary,
            Position = existingEmployeeById.Position,
            DateOfBirth = existingEmployeeById.DateOfBirth,
            Gender = existingEmployeeById.Gender
        };

        return employeeDto;
    }

    public async Task UpdateEmployee(UpdateEmployeeInput input)
    {
        Employee existingEmployeeById = await _repositoryEmployeeAppService.FirstOrDefaultAsync(x => x.Id == input.Id);
        
        if (existingEmployeeById == null)
        {
            throw new UserFriendlyException("Employee not found");
        }
        
        existingEmployeeById.FirstName = input.FirstName;
        existingEmployeeById.LastName = input.LastName;
        existingEmployeeById.Email = input.Email;
        existingEmployeeById.PhoneNumber = input.PhoneNumber;
        existingEmployeeById.Address = input.Address;
        existingEmployeeById.Salary = input.Salary;
        existingEmployeeById.Position = input.Position;
        existingEmployeeById.DateOfBirth = input.DateOfBirth;
        existingEmployeeById.Gender = input.Gender;
        
        await _repositoryEmployeeAppService.UpdateAsync(existingEmployeeById);
    }

    public async Task DeleteEmployee(int id)
    {
        Employee existingEmployeeById = await _repositoryEmployeeAppService.FirstOrDefaultAsync(x => x.Id == id);
        
        if (existingEmployeeById == null)
        {
            throw new UserFriendlyException("Employee not found");
        }
        
        await _repositoryEmployeeAppService.DeleteAsync(existingEmployeeById);
    }
}