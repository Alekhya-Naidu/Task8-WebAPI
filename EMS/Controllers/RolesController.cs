using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.BAL.Interfaces;
using EMS.DB.Models;
using EMS.ResponseModel.Enums;
using EMS.ResponseModel;
using EMS.DAL.DTO;

namespace EMS.Controllers;

[ApiController]
[Route("[controller]")]

public class RolesController : ControllerBase
{
    private readonly IRolesService _rolesService;

    public RolesController(IRolesService rolesService)
    {
        _rolesService = rolesService;
    }

    [HttpGet]
    public ApiResponse<IEnumerable<Role>> GetAllRoles()
    {
        var roles = _rolesService.GetAllRoles();
        if (roles == null || !roles.Any())
        {
            return new ApiResponse<IEnumerable<Role>>(ResponseStatus.Error, null, ErrorCode.NotFound);
        }
        return new ApiResponse<IEnumerable<Role>>(ResponseStatus.Success, roles);
    }

    [HttpGet("{id}")]
    public ApiResponse<Role> GetRoleById(int id)
    {
        var role = _rolesService.GetRoleById(id);
        if (role == null)
        {
            return new ApiResponse<Role>(ResponseStatus.Error, null, ErrorCode.NotFound);
        }
        return new ApiResponse<Role>(ResponseStatus.Success, role);
    }

    [HttpPost]
    public ApiResponse<int> CreateRole(Role role)
    {
        var roleId = _rolesService.AddRole(role);
        if (roleId > 0)
        {
            return new ApiResponse<int>(ResponseStatus.Success, roleId);
        }
        else
        {
            return new ApiResponse<int>(ResponseStatus.Error, 0, ErrorCode.BadRequest);
        }
    }
}
