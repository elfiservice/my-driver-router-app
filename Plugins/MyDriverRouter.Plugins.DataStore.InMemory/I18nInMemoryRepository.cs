using MyDriverRouter.UseCases;

namespace MyDriverRouter.Plugins.DataStore.InMemory;

public class I18nInMemoryRepository : Ii18nRepository
{
    private string _currentLanguage;

    public I18nInMemoryRepository()
    {
        this._currentLanguage = "";
    }

    public Task SetLanguage(string language)
    {
        this._currentLanguage = language;
        return Task.CompletedTask;
    }
}
