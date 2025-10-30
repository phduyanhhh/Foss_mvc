using G7.Foss.Roles.Dto;
using System.Collections.Generic;

namespace G7.Foss.Web.Models.Roles;

public class RoleListViewModel
{
    public IReadOnlyList<PermissionDto> Permissions { get; set; }
}
