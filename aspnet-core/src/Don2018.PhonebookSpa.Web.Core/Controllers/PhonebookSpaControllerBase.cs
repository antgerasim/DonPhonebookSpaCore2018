using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Don2018.PhonebookSpa.PhoneBook.Phones;
using Microsoft.AspNetCore.Identity;

namespace Don2018.PhonebookSpa.Controllers
{
    public abstract class PhonebookSpaControllerBase: AbpController
    {
        protected PhonebookSpaControllerBase()
        {
            LocalizationSourceName = PhonebookSpaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
