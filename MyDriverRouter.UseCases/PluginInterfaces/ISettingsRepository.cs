using MyDriverRouter.CoreBusiness;

namespace MyDriverRouter.UseCases.PluginInterfaces;

public interface ISettingsRepository
{
    Task SetTenant(string tenant);
    Task<string> GetTenant();
    Task<IEnumerable<Language>> GetLanguagesAvaliebles(string tenant);
}
