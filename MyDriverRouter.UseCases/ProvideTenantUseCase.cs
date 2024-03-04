using MyDriverRouter.CoreBusiness;

namespace MyDriverRouter.UseCases;

public class ProvideTenantUseCase : IProvideTenantUseCase
{
    private readonly ISettingsRepository settingsRepository;

    public ProvideTenantUseCase(ISettingsRepository settingsRepository)
    {
        this.settingsRepository = settingsRepository;
    }

    public async Task ExecuteAsync(string tenant)
    {
        await this.settingsRepository.SetTenant(tenant);
    }
}
