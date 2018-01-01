using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Don2018.PhonebookSpa.Configuration;

namespace Don2018.PhonebookSpa.Web.Host.Startup
{
    [DependsOn(
       typeof(PhonebookSpaWebCoreModule))]
    public class PhonebookSpaWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PhonebookSpaWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhonebookSpaWebHostModule).GetAssembly());
        }
    }
}
