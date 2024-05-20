using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.BAL.Interfaces;

public interface IMasterDataService
{
    Location GetLocationFromName(string locationName);
    Department GetDepartmentFromName(string departmentName);
    Manager GetManagerFromName(string managerName);
    Project GetProjectFromName(string projectName);
}