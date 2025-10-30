using G7.Foss.Configuration.Dto;
using System.Threading.Tasks;

namespace G7.Foss.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
