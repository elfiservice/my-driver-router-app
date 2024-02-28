namespace MyDriverRouter.UseCases;

// All the code in this file is included in all platforms.
public class ProvideTenantUseCase : IProvideTenantUseCase
{
    private readonly IProvideTenantRepository provideTenantRepository;

    public ProvideTenantUseCase(IProvideTenantRepository provideTenantRepository)
    {
        this.provideTenantRepository = provideTenantRepository;
    }

    public async Task ExecuteAsync(string tenant)
    {
        await this.provideTenantRepository.SetTenant(tenant);
    }
}
