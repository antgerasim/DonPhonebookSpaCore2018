using System.Collections.Generic;

namespace Don2018.PhonebookSpa.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
