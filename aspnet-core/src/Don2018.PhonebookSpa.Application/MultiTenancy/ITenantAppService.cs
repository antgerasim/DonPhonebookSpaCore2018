using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don2018.PhonebookSpa.MultiTenancy.Dto;

namespace Don2018.PhonebookSpa.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
