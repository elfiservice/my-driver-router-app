using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases.PluginInterfaces;
using LocalizationResourceManager.Maui;

namespace MyDriverRouter.UseCases;

public class SelectLanguageUseCase : ISelectLanguageUseCase
{
    private readonly Ii18nRepository _i18nRepository;
    private readonly ILocalizationResourceManager _localizationResourceManager;

    public SelectLanguageUseCase(
        Ii18nRepository i18nRepository,
        ILocalizationResourceManager localizationResourceManager)
    {
        _i18nRepository = i18nRepository;
        _localizationResourceManager = localizationResourceManager;
    }

    public async Task ExecuteAsync(Language language)
    {
        _localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo(language.Code);
        
        await _i18nRepository.SetLanguage(language.Description);
    }
}
