using G7.Foss.Roles.Dto;
using G7.Foss.Users.Dto;
using System.Collections.Generic;
using System.Linq;

namespace G7.Foss.Web.Models.Users;

public class EditUserModalViewModel
{
    public UserDto User { get; set; }

    public IReadOnlyList<RoleDto> Roles { get; set; }

    public bool UserIsInRole(RoleDto role)
    {
        return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
    }
}
