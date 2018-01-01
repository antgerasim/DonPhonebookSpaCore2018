using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don2018.PhonebookSpa.MultiTenancy;

namespace Don2018.PhonebookSpa.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
