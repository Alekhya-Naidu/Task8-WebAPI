using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.BAL.Interfaces;
using EMS.DAL.Interfaces;
using EMS.DB.Models;

namespace EMS.BAL.BAL;
public class MasterDataService : IMasterDataService
{
    private readonly IMasterDataRepository _masterDataRepo;

    public MasterDataService(IMasterDataRepository masterDataRepo)
    {
        _masterDataRepo = masterDataRepo;
    }

    public Location GetLocationFromName(string locationName)
    {
        return _masterDataRepo.GetLocationFromName(locationName);
    }

    public Department GetDepartmentFromName(string departmentName)
    {
        return _masterDataRepo.GetDepartmentFromName(departmentName);
    }

    public Manager GetManagerFromName(string managerName)
    {
        return _masterDataRepo.GetManagerFromName(managerName);
    }

    public Project GetProjectFromName(string projectName)
    {
        return _masterDataRepo.GetProjectFromName(projectName);
    }
}
