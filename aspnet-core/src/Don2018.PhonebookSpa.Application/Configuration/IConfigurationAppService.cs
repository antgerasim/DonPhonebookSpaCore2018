using System.Threading.Tasks;
using Don2018.PhonebookSpa.Configuration.Dto;

namespace Don2018.PhonebookSpa.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
