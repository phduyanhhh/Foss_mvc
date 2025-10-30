using Abp.Application.Services;
using G7.Foss.Sessions.Dto;
using System.Threading.Tasks;

namespace G7.Foss.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
