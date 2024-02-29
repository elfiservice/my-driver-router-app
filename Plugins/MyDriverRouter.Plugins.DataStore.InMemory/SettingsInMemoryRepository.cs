using MyDriverRouter.UseCases;

namespace MyDriverRouter.Plugins.DataStore.InMemory;

public class SettingsInMemoryRepository : ISettingsRepository
{

    private string _tenant;
    private IEnumerable<string> _languages;

    public SettingsInMemoryRepository()
    {
        _tenant = "";
        _languages = new List<string> { "English", "Portuges" };
    }

    public Task<IEnumerable<string>> GetLanguagesAvaliebles(string tenant)
    {
        return Task.FromResult(_languages);
    }

    public Task<string> GetTenant()
    {
        return Task.FromResult(_tenant);
    }

    public Task SetTenant(string tenant)
    {
        _tenant = tenant;
        return Task.CompletedTask;
    }
}
