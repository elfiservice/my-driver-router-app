namespace MyDriverRouter.UseCases;

public interface ISettingsRepository
{
    Task SetTenant(string tenant);
    Task<IEnumerable<string>> GetLanguagesAvaliebles(string tenant); 
}
