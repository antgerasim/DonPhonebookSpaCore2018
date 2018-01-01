using Abp.Authorization;
using Don2018.PhonebookSpa.Authorization.Roles;
using Don2018.PhonebookSpa.Authorization.Users;

namespace Don2018.PhonebookSpa.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
