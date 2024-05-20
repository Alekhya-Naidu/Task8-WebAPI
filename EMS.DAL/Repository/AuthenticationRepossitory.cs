using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Linq;
using BCrypt.Net;
using EMS.DAL.Interfaces;
using EMS.DAL.DTO;
using EMS.DAL.Mapper; 
using EMS.DB.Models;

namespace EMS.DAL.Repository;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly EMSDbContext _dbContext;
    private readonly EmployeeMapper _mapper;

    public AuthenticationRepository(EMSDbContext dbContext, EmployeeMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public int RegisterEmployee(RegisterDTO registerEmp)
    {
        string hashedPassword = HashPassword(registerEmp.Password);
        var employee = _mapper.MapRegisterDtoToEmployee(registerEmp, hashedPassword);
        
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
        return employee.Id;
    }

    public EmployeeDetail GetEmployeeByEmail(string email)
    {
        var employee = _dbContext.Employees
                .Include(e => e.Location)
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Include(e => e.Manager)
                .Include(e => e.Project)
                .FirstOrDefault(e => e.Email == email);

        return employee != null ? _mapper.MapEmployeeToEmployeeDTO(employee) : null;
    }

    public bool Authenticate(string email, string password)
    {
        var employee = _dbContext.Employees.FirstOrDefault(e => e.Email == email);
        return VerifyPassword(password, employee.Password);
    }
    
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}

