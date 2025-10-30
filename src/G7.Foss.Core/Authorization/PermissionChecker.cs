using Abp.Authorization;
using G7.Foss.Authorization.Roles;
using G7.Foss.Authorization.Users;

namespace G7.Foss.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
