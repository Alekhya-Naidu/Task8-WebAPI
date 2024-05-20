using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using System.Security.Cryptography;
using System.Linq;
using EMS.DAL.Interfaces;
using EMS.DAL.DTO;
using EMS.DAL.Mapper;
using EMS.DB.Models;

namespace EMS.DAL.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EMSDbContext _dbContext;
    private readonly IMasterDataRepository _masterDataRepo;
    private readonly IRolesRepository _rolesRepo;
    private readonly EmployeeMapper _mapper;

    public EmployeeRepository(EMSDbContext dbContext, IMasterDataRepository masterDataRepo, IRolesRepository rolesRepo, EmployeeMapper mapper)
    {
        _dbContext = dbContext;
        _masterDataRepo = masterDataRepo;
        _rolesRepo = rolesRepo;
        _mapper = mapper;
    }

    public int Insert(EmployeeDetail employeeDetail)
    {
        var employee = _mapper.MapEmployeeDtoToEmployee(employeeDetail);
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
        return employee.Id;
    }

    public int Update(EmployeeDetail employeeDetail)
    {
        var existingEmployee = _dbContext.Employees.Find(employeeDetail.Id);
        if (existingEmployee == null)
        {
            return -1;
        }
        _mapper.MapEmployeeDetailToEmployee(employeeDetail, existingEmployee);
        _dbContext.SaveChanges();
        return existingEmployee.Id;
    }

    public int UpdateRow(int id, JsonPatchDocument<EmployeeDetail> patchDocument)
    {
        var employee = GetEmployeeById(id);
        if (employee == null)
        {
            return 0; 
        }
        patchDocument.ApplyTo(employee);

        var rowsAffected = Update(employee);
        return rowsAffected > 0 ? rowsAffected : 0;
    }

    public int Delete(int id)
    {
        var employeeToBeDeleted = _dbContext.Employees.Find(id);
        if(employeeToBeDeleted == null)
        {
            return 0;
        }
        _dbContext.Employees.Remove(employeeToBeDeleted);
        return _dbContext.SaveChanges();
    }

    public EmployeeDetail GetEmployeeById(int id)
    {
        var existingEmployee = _dbContext.EmployeeDetails
            .FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return null;
        }
        return existingEmployee; 
    }

    // public IEnumerable<EmployeeDetail> GetAll()
    // {
    //     return _dbContext.EmployeeDetails.ToList();
    // }

    public PaginatedResult<EmployeeDetail> GetAll(int pageIndex, int pageSize)
    {
        var query = _dbContext.EmployeeDetails.AsQueryable();
        var totalCount = query.Count();
        var items = query.Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .ToList();

        return new PaginatedResult<EmployeeDetail>(items, pageIndex, pageSize, totalCount);
    }
    public IEnumerable<EmployeeDetail> Filter(EmployeeFilter filter)
    {
        var query = _dbContext.Employees.AsQueryable();
        if (filter.Id.HasValue)
        {
            query = query.Where(e => e.Id == filter.Id);
        }
        if (!string.IsNullOrEmpty(filter.FirstName))
        {
            query = query.Where(e => e.FirstName.Contains(filter.FirstName));
        }
        if (!string.IsNullOrEmpty(filter.LocationName))
        {
            var location = _masterDataRepo.GetLocationFromName(filter.LocationName);
            if (location != null)
            {
                query = query.Where(e => e.LocationId == location.Id);
            }
        }
        if (!string.IsNullOrEmpty(filter.DepartmentName))
        {
            var department = _masterDataRepo.GetDepartmentFromName(filter.DepartmentName);
            if (department != null)
            {
                query = query.Where(e => e.DepartmentId == department.Id);
            }
        }
        var employees = query.Include(e => e.Location)
                             .Include(e => e.Department)
                             .Include(e => e.Role)
                             .Include(e => e.Project)
                             .Include(e => e.Manager)
                             .ToList();

        return employees
            .Select(emp => _mapper.MapEmployeeToEmployeeDTO(emp)).ToList();
    }
}