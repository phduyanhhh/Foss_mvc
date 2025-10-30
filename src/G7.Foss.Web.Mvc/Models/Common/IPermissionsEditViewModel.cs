using G7.Foss.Roles.Dto;
using System.Collections.Generic;

namespace G7.Foss.Web.Models.Common;

public interface IPermissionsEditViewModel
{
    List<FlatPermissionDto> Permissions { get; set; }
}