using System;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Don2018.PhonebookSpa.Authorization.Roles;
using Don2018.PhonebookSpa.Authorization.Users;
using Don2018.PhonebookSpa.Configuration;
using Don2018.PhonebookSpa.Localization;
using Don2018.PhonebookSpa.MultiTenancy;
using Don2018.PhonebookSpa.Timing;

namespace Don2018.PhonebookSpa
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class PhonebookSpaCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            PhonebookSpaLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = PhonebookSpaConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            //BUG https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2735
            AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue9825", true);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhonebookSpaCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
