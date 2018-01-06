using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using Don2018.PhonebookSpa.PhoneBook.Phones;

namespace Don2018.PhonebookSpa.Localization
{
    public static class PhonebookSpaLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PhonebookSpaConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PhonebookSpaLocalizationConfigurer).GetAssembly(),
                        "Don2018.PhonebookSpa.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
