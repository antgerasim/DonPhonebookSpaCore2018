using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Don2018.PhonebookSpa.Configuration.Dto;

namespace Don2018.PhonebookSpa.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PhonebookSpaAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
