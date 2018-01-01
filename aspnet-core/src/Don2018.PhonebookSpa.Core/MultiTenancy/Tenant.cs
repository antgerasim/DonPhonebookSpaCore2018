using Abp.MultiTenancy;
using Don2018.PhonebookSpa.Authorization.Users;

namespace Don2018.PhonebookSpa.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
