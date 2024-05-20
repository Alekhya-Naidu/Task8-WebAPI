using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using EMS.DB.Models;
using EMS.DAL.DTO;

namespace EMS.BAL.Interfaces;

public interface IEmployeeService
{
    int Insert(EmployeeDetail employeeDetail);
    int Update(EmployeeDetail employeeDetail);
    int UpdateRow(int id, JsonPatchDocument<EmployeeDetail> patchDocument);
    int Delete(int id);
    EmployeeDetail GetEmployeeById(int id);
    PaginatedResult<EmployeeDetail> GetAll(int pageIndex, int pageSize);
    IEnumerable<EmployeeDetail> Filter(EmployeeFilter filters);
}