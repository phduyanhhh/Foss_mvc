using Abp.Authorization;
using Abp.Runtime.Session;
using G7.Foss.Configuration.Dto;
using System.Threading.Tasks;

namespace G7.Foss.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : FossAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
