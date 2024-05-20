using System;
using System.Linq;  
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using EMS.BAL.Interfaces;
using EMS.DAL.Interfaces;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.BAL.BAL;
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepo;

    public EmployeeService(IEmployeeRepository employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    public int Insert(EmployeeDetail employeeDetail)
    {
        return _employeeRepo.Insert(employeeDetail);
    }

    public int Update (EmployeeDetail employeeDetail)   
    {
        return _employeeRepo.Update(employeeDetail);
    }

    public int UpdateRow(int id, JsonPatchDocument<EmployeeDetail> patchDocument)
    {
        return _employeeRepo.UpdateRow(id, patchDocument);
    }

    public int Delete (int id)
    {
        return _employeeRepo.Delete(id);
    }

    public EmployeeDetail GetEmployeeById(int id)
    {
        return _employeeRepo.GetEmployeeById(id);
    }
    
    public PaginatedResult<EmployeeDetail> GetAll(int pageIndex, int pageSize)
    {
        return _employeeRepo.GetAll(pageIndex, pageSize);
    }

    public IEnumerable<EmployeeDetail> Filter(EmployeeFilter filters)
    {
        return _employeeRepo.Filter(filters);
    }
}