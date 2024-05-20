using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.BAL.Interfaces;
using EMS.DAL.Interfaces;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.BAL.BAL;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepo;

    public AuthenticationService(IAuthenticationRepository authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }

    public int RegisterEmployee(RegisterDTO registerEmp)
    {
        return _authenticationRepo.RegisterEmployee(registerEmp);
    }

    public EmployeeDetail GetEmployeeByEmail(string email)
    {
        return _authenticationRepo.GetEmployeeByEmail(email);
    }

    public bool Authenticate(string email, string password)
    {
        return _authenticationRepo.Authenticate(email, password);
    }
}

