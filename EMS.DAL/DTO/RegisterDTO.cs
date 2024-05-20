using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.DAL.DTO;

public class RegisterDTO
{
    public int Id { get; set; }
    public required string Uid { get; set; }
    public required string FirstName { get; set; }   
    public required string LastName { get; set; }
    public required DateTime DOB { get; set; }
    public required string Email { get; set; }
    public string? MobileNumber { get; set; }
    public required DateTime JoiningDate { get; set; }
    public string? LocationName { get; set; }
    public string? DepartmentName { get; set; }
    public string? RoleName { get; set; }
    public required bool IsManager { get; set; }
    public string? ManagerName { get; set; }
    public string? ProjectName { get; set; }
    public string Password { get; set; }
}