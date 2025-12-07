using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using G7.Foss.Services.Employees.Dtos;

namespace G7.Foss.Services.Employees;

public interface IEmployeeAppServices : IApplicationService
{
    Task Create(CreateEmployeeInput input);
    Task<PagedResultDto<EmployeeListDto>> GetList(GetAllEmployeeInput input);
}