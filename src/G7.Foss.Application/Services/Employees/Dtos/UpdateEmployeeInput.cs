using System;
using G7.Foss.Entities;

namespace G7.Foss.Services.Employees.Dtos;

public class UpdateEmployeeInput
{
    public int Id {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public double Salary { get; set; }
    public PositionEnum Position { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderEnum Gender { get; set; }
}