using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Plugins.DataStore.InMemory;

public class SettingsInMemoryRepository : ISettingsRepository
{

    private string _tenant;
    private IEnumerable<Language> _languages;

    public SettingsInMemoryRepository()
    {
        _tenant = "";
        _languages = new List<Language>();
    }

    public Task<IEnumerable<Language>> GetLanguagesAvaliebles(string tenant)
    {
        return Task.FromResult(_languages);
    }

    public Task<string> GetTenant()
    {
        return Task.FromResult(_tenant);
    }

    public Task SetTenant(string tenant)
    {
        this.GetAllLanguagesAPI(tenant);
        this.SetTenantInMemroy(tenant);
        return Task.CompletedTask;
    }

    private void SetTenantInMemroy(string tenant)
    {
        Settings settings = new Settings {
            LastTenantProvided = tenant
        };

        _tenant = settings.LastTenantProvided;
    }

    private void GetAllLanguagesAPI(string tenant)
    {   
        i18n i18nFromAPI = new i18n();
        i18nFromAPI.AvaliableLanguages = new[] {
            new Language { Description = "English" },
            new Language { Description = "Portuguese" }
        };

        _languages = i18nFromAPI.AvaliableLanguages;
    }
}
