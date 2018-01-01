using System.Threading.Tasks;
using Abp.Application.Services;
using Don2018.PhonebookSpa.Sessions.Dto;

namespace Don2018.PhonebookSpa.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
