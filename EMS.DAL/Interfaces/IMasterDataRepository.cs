using System;
using System.Collections.Generic;
using EMS.DAL.DTO;
using EMS.DB.Models;

namespace EMS.DAL.Interfaces;

public interface IMasterDataRepository
{
    Location GetLocationFromName(string locationName);
    Department GetDepartmentFromName(string departmentName);
    Manager GetManagerFromName(string managerName);
    Project GetProjectFromName(string projectName);
}