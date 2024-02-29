using MyDriverRouter.CoreBusiness;

namespace MyDriverRouter.UseCases;


public interface IProvideTenantUseCase
{
    Task<IEnumerable<Language>> ExecuteAsync(string tenant);
}