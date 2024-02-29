namespace MyDriverRouter.UseCases;

// All the code in this file is included in all platforms.
public class ProvideTenantUseCase : IProvideTenantUseCase
{
    private readonly ISettingsRepository settingsRepository;

    public ProvideTenantUseCase(ISettingsRepository settingsRepository)
    {
        this.settingsRepository = settingsRepository;
    }

    public async Task<IEnumerable<string>> ExecuteAsync(string tenant)
    {
        await this.settingsRepository.SetTenant(tenant);
        return await this.settingsRepository.GetLanguagesAvaliebles(tenant);
    }
}
