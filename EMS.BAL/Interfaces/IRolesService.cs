using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.DB.Models;

namespace EMS.BAL.Interfaces;

public interface IRolesService
{
    IEnumerable<Role> GetAllRoles();
    Role GetRoleFromName(string roleName);
    Role GetRoleById(int roleId);
    int AddRole(Role role);
}
