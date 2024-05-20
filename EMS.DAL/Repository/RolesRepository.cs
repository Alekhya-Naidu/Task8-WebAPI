using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.DB.Models;
using EMS.DAL.Interfaces;

namespace EMS.DAL.Repository;
public class RolesRepository : IRolesRepository
{
    private readonly EMSDbContext _dbContext;

    public RolesRepository(EMSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Role> GetAllRoles()
    {
        return _dbContext.Roles.ToList();
    }

    public Role GetRoleFromName(string roleName)
    {
        return _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
    }

    public Role GetRoleById(int roleId)
    {
        return _dbContext.Roles.Find(roleId);
    }

    public int AddRole(Role role)
    {
        _dbContext.Roles.Add(role);
        _dbContext.SaveChanges();
        return role.Id;
    }
}

