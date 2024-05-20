using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EMS.DB.Models;
using EMS.DAL.Interfaces;

namespace EMS.DAL.Repository;

public class MasterDataRepository : IMasterDataRepository
{
    private readonly EMSDbContext _dbContext;

    public MasterDataRepository(EMSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Location GetLocationFromName(string locationName)
    {
        return _dbContext.Locations.FirstOrDefault(l => l.Name == locationName);
    }

    public Department GetDepartmentFromName(string departmentName)
    {
        return _dbContext.Departments.FirstOrDefault(d => d.Name == departmentName);
    }

    public Manager GetManagerFromName(string managerName)
    {
        var managerEmployee = _dbContext.Employees.FirstOrDefault(e => e.FirstName == managerName && e.IsManager);
        if (managerEmployee != null)
        {
            return new Manager { Id = managerEmployee.Id, FirstName = managerEmployee.FirstName };
        }
        else
        {
            return null; 
        };
    }

    public Project GetProjectFromName(string projectName)
    {
        return _dbContext.Projects.FirstOrDefault(p => p.Name == projectName);
    }
}
