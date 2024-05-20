using System;
using System.Collections.Generic;
using EMS.DB.Models;

namespace EMS.DAL.Interfaces;

public interface IRolesRepository
{
    IEnumerable<Role> GetAllRoles();
    Role GetRoleFromName(string rolenNme);
    Role GetRoleById(int roleId);
    int AddRole(Role role);
}