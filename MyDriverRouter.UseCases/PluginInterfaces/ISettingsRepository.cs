namespace MyDriverRouter.UseCases;

public interface ISettingsRepository
{
    Task SetTenant(string tenant);
    Task<string> GetTenant();
    Task<IEnumerable<string>> GetLanguagesAvaliebles(string tenant);
}
