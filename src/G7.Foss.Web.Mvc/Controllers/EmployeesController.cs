using System;
using System.Linq;
using System.Threading.Tasks;
using G7.Foss.Controllers;
using G7.Foss.Entities;
using G7.Foss.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace G7.Foss.Web.Controllers;

public class EmployeesController : FossControllerBase
{
    private readonly IEmployeeAppServices _employeeAppServices;
    public EmployeesController(
        IEmployeeAppServices employeeAppServices
    )
    {
        _employeeAppServices = employeeAppServices;
    }

    public IActionResult Index()
    {
        ViewBag.GenderList = Enum.GetValues(typeof(GenderEnum))
            .Cast<GenderEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
        
        ViewBag.PositionList = Enum.GetValues(typeof(PositionEnum))
            .Cast<PositionEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
        return View();
    }

    public async Task<IActionResult> EditModal(int EmployeeId)
    {
        var output = await _employeeAppServices.GetEmployeeById(EmployeeId);
        
        ViewBag.GenderList = Enum.GetValues(typeof(GenderEnum))
            .Cast<GenderEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();

        ViewBag.PositionList = Enum.GetValues(typeof(PositionEnum))
            .Cast<PositionEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
        
        return PartialView("_EditModal", output);
    }
}