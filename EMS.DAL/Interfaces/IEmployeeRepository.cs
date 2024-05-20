using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.DAL.Interfaces;

public interface IEmployeeRepository
{
    int Insert(EmployeeDetail employeeDetail);
    int Update(EmployeeDetail employeeDetail);
    int UpdateRow(int id, JsonPatchDocument<EmployeeDetail> patchDocument);
    int Delete(int id);
    EmployeeDetail GetEmployeeById(int id);
    PaginatedResult<EmployeeDetail> GetAll(int pageIndex, int pageSize);
    IEnumerable<EmployeeDetail> Filter(EmployeeFilter filters);
}
