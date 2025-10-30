using G7.Foss.Roles.Dto;
using System.Collections.Generic;

namespace G7.Foss.Web.Models.Users;

public class UserListViewModel
{
    public IReadOnlyList<RoleDto> Roles { get; set; }
}
