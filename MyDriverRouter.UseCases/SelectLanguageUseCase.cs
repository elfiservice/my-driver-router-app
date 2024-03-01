namespace MyDriverRouter.UseCases;

public class SelectLanguageUseCase : ISelectLanguageUseCase
{
    private readonly Ii18nRepository _i18nRepository;

    public SelectLanguageUseCase(Ii18nRepository i18nRepository)
    {
        _i18nRepository = i18nRepository;
    }

    public async Task SetLanguage(string language)
    {
        await _i18nRepository.SetLanguage(language);
    }
}
