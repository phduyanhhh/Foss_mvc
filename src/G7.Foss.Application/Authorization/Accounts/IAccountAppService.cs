using Abp.Application.Services;
using G7.Foss.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace G7.Foss.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
