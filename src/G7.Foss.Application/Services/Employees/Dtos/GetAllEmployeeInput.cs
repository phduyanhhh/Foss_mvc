using Abp.Application.Services.Dto;

namespace G7.Foss.Services.Employees.Dtos;

public class GetAllEmployeeInput : PagedAndSortedResultRequestDto
{
    public string Search { get; set; }
}