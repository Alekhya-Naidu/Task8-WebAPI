using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.BAL.Interfaces;
using EMS.DAL.Interfaces;
using EMS.DB.Models;

namespace EMS.BAL.BAL;
public class RolesService : IRolesService
{
    private readonly IRolesRepository _rolesRepo;

    public RolesService(IRolesRepository rolesRepo)
    {
        _rolesRepo = rolesRepo;
    }

    public IEnumerable<Role> GetAllRoles()
    {
        return _rolesRepo.GetAllRoles();
    }

    public Role GetRoleFromName(string roleName)
    {
        return _rolesRepo.GetRoleFromName(roleName);
    }
    
    public Role GetRoleById(int roleId)
    {
        return _rolesRepo.GetRoleById(roleId);
    }

    public int AddRole(Role role)
    {
        return _rolesRepo.AddRole(role);
    }
}

