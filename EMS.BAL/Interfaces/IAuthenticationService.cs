using System;
using System.Collections.Generic;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.BAL.Interfaces;

public interface IAuthenticationService
{
    int RegisterEmployee(RegisterDTO registerEmp);
    EmployeeDetail GetEmployeeByEmail(string email);
    bool Authenticate(string email, string password);
}