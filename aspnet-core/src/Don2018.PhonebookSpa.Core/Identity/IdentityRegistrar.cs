using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Don2018.PhonebookSpa.Authorization;
using Don2018.PhonebookSpa.Authorization.Roles;
using Don2018.PhonebookSpa.Authorization.Users;
using Don2018.PhonebookSpa.Editions;
using Don2018.PhonebookSpa.MultiTenancy;

namespace Don2018.PhonebookSpa.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
