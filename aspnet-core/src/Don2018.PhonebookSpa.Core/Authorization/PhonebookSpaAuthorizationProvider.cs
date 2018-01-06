using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using Don2018.PhonebookSpa.PhoneBook.Phones;

namespace Don2018.PhonebookSpa.Authorization
{
    public class PhonebookSpaAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"),
                multiTenancySides: MultiTenancySides.Host);
            /*Don added*/
            // context.CreateChildPermission(AppPermissions.Pages_Tenant_PhoneBook, L("PhoneBook"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_Tenant_PhoneBook, L("PhoneBook"),
            //  multiTenancySides: MultiTenancySides.Tenant);
            var phoneBook = context.CreatePermission(PermissionNames.Pages_Tenant_PhoneBook, L("PhoneBook"),
                multiTenancySides: MultiTenancySides.Tenant);
            phoneBook.CreateChildPermission(PermissionNames.Pages_Tenant_PhoneBook_CreatePerson, L("CreateNewPerson"),
                multiTenancySides: MultiTenancySides.Tenant);
            phoneBook.CreateChildPermission(PermissionNames.Pages_Tenant_PhoneBook_DeletePerson, L("DeletePerson"),
                multiTenancySides: MultiTenancySides.Tenant);
            phoneBook.CreateChildPermission(PermissionNames.Pages_Tenant_PhoneBook_EditPerson, L("EditPerson"),
                multiTenancySides: MultiTenancySides.Tenant);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PhonebookSpaConsts.LocalizationSourceName);
        }
    }
}