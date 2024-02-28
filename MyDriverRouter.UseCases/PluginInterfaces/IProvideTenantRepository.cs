namespace MyDriverRouter.UseCases;

public interface IProvideTenantRepository
{
    Task SetTenant(string tenant);
}
