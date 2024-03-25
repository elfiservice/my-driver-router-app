using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases.PluginInterfaces;

namespace MyDriverRouter.UseCases;

public class ProvideTenantUseCase : IProvideTenantUseCase
{
    private readonly ISettingsRepository _settingsRepository;

    public ProvideTenantUseCase(ISettingsRepository settingsRepository)
    {
        this._settingsRepository = settingsRepository;
    }

    public async Task ExecuteAsync(string tenant)
    {
        await this._settingsRepository.SetTenant(tenant);
    }
}
