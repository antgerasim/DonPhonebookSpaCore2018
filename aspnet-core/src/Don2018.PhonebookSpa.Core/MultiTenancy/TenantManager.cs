using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Don2018.PhonebookSpa.Authorization.Users;
using Don2018.PhonebookSpa.Editions;

namespace Don2018.PhonebookSpa.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
