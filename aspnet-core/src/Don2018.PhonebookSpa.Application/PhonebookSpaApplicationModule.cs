using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Don2018.PhonebookSpa.Authorization;

namespace Don2018.PhonebookSpa
{
    [DependsOn(
        typeof(PhonebookSpaCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PhonebookSpaApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PhonebookSpaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PhonebookSpaApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
