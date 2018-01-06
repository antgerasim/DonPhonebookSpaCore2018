using Don2018.PhonebookSpa.PhoneBook.Phones;
using Xunit;

namespace Don2018.PhonebookSpa.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            if (!PhonebookSpaConsts.MultiTenancyEnabled)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
